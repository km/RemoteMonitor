using RemoteMonitor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace RemoteMonitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Monitor : ContentPage
    {
        private Client _client;
        private CPU _cpu;
        private GPU _gpu;
        private PhysicalDisk _disk;
        private Ram _ram;
        public Monitor(Client client, GPU gpu, PhysicalDisk disk, Ram ram)
        {
            InitializeComponent();
            _client = client;
            _gpu = gpu;
            _disk = disk;
            _ram = ram;
        }
        public Monitor(JArray jsonArray) 
        { 
            InitializeComponent();
            _cpu = new CPU(jsonArray[0].ToObject<JObject>());
            _gpu = new GPU(jsonArray[1][0].ToObject<JObject>());
            _ram = new Ram(jsonArray[2].ToObject<JObject>());
            _disk = new PhysicalDisk(jsonArray[3][0].ToObject<JObject>());
        }
        private void Update(JArray jsonArray)
        {
            refreshControl.IsRefreshing = false;
            _cpu.update(jsonArray[0].ToObject<JObject>());
            _gpu.update(jsonArray[1][0].ToObject<JObject>());
            _ram.update(jsonArray[2].ToObject<JObject>());
            _disk.update(jsonArray[3][0].ToObject<JObject>());
         

            lastUpdated.Text = "Last Updated " + DateTime.Now.ToLocalTime().ToString();
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            try
            {
               string data = _client.requestData();
               Update(JArray.Parse(data));
            }
            catch (Exception)
            {

                
            }
            
        }
      
    }
}