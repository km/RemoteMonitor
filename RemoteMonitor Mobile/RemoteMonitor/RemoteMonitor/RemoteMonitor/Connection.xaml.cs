using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RemoteMonitor
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage(string text)
        {
            InitializeComponent();
            setFields();
            error.Text = text;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            error.Text = "";
            try
            {
                Client client = new Client(ip.Text, Convert.ToInt32(port.Text), keyword.Text);
                bool connected = client.Connect();
                

                if (connected)
                {
                    Preferences.Set("ip", ip.Text);
                    Preferences.Set("port", port.Text);
                    Preferences.Set("keyword", keyword.Text);
                    error.TextColor = Color.Green;
                    error.Text = "Successfully connected!";
                    Navigation.PushAsync((new Monitor(JArray.Parse(client.requestData()), client)));
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

                }
                else
                {
                    error.Text = "Failed to connect to server";
                }
            }
            catch (Exception)
            {
                error.Text = "Failed to connect to server";
            }
           
        }


        private void setFields() 
        {
            string ip = Preferences.Get("ip", "");
            int port = Convert.ToInt32(Preferences.Get("port", ""));
            string keyword = Preferences.Get("keyword", "");
            
            this.ip.Text = ip;
            this.port.Text = port.ToString();
            this.keyword.Text = keyword;

        }
    }
}
