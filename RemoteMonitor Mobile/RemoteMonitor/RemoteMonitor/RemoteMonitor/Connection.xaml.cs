using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RemoteMonitor
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
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
                    error.TextColor = Color.Green;
                    error.Text = "Successfully connected!";
                    App.Current.MainPage = new Monitor(client);
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
    }
}
