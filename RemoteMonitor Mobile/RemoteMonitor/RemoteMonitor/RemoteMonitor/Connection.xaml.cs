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
            try
            {
                setFields();

            }
            catch (Exception)
            {
            }
            error.Text = text;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            error.Text = "";
            try
            {
                connect.IsEnabled = false;
                Client client = new Client(ip.Text, Convert.ToInt32(port.Text), keyword.Text);
                bool connected = await client.ConnectAsync();
                
                Debug.WriteLine(connected);
                if (connected)
                {
                    Preferences.Set("ip", ip.Text);
                    Preferences.Set("port", port.Text);
                    Preferences.Set("keyword", keyword.Text);
                    error.TextColor = Color.Green;
                    error.Text = "Successfully connected!";
                    var newPage = new Monitor(JArray.Parse(await client.RequestDataAsync()), client);
                    var animation = new Animation(v => newPage.Opacity = v, 0, 1);

                    animation.Commit(newPage, "FadeAnimation", length: 500, easing: Easing.Linear);
                    await Navigation.PushAsync(newPage);
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

                }
                else
                {
                    connect.IsEnabled = true;

                    error.Text = "Failed to connect to server";

                }
            }
            catch (Exception ex)
            {
                connect.IsEnabled = true;

                error.Text = "Failed to connect to server";
                Debug.WriteLine(ex);
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
