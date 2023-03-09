using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteMonitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Monitor : ContentPage
    {
        private Client _client;
        public Monitor(Client client)
        {
            InitializeComponent();
            _client = client;
        }
        public Monitor() { InitializeComponent(); Update();
        }
        private void Update()
        {
            refreshControl.IsRefreshing = false;
            _client.requestData();
            lastUpdated.Text = "Last Updated " + DateTime.Now.ToLocalTime().ToString();
        }
        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            Update();
            
        }
    }
}