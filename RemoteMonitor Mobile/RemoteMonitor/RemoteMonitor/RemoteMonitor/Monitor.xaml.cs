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
            Update();
        }
        private void Update() 
        {
            t.IsRefreshing= false;
        }
        public Monitor() { InitializeComponent(); }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            Update();
            
        }
    }
}