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
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            _client = client;
            _gpu = gpu;
            _disk = disk;
            _ram = ram;
        }
        public Monitor(JArray jsonArray, Client c) 
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            _client = c;

            _cpu = new CPU(jsonArray[0].ToObject<JObject>());
            try
            {
                _gpu = new GPU(jsonArray[1][0].ToObject<JObject>());

            }
            catch (Exception)
            {
                _gpu = new GPU();
            }
            _ram = new Ram(jsonArray[2].ToObject<JObject>());
            _disk = new PhysicalDisk(jsonArray[3][0].ToObject<JObject>());

            setFields();
        }
        public Monitor()
        {
            InitializeComponent();
        }
        private void Update(JArray jsonArray)
        {
            refreshControl.IsRefreshing = false;
            _cpu.update(jsonArray[0].ToObject<JObject>());
            try
            {
                _gpu.update(jsonArray[1][0].ToObject<JObject>());
                _disk.update(jsonArray[3][0].ToObject<JObject>());

            }
            catch (Exception)
            {

            }
            _ram.update(jsonArray[2].ToObject<JObject>());
         

            lastUpdated.Text = "Last Updated " + DateTime.Now.ToLocalTime().ToString();
        }

        //sets the fields to the values of the components
        private void setFields()
        {
            //cpu
            if (_cpu.componentName != "")
               cpuName.Text = _cpu.componentName.Trim();
            else
                cpuName.Text = "CPU";

            if (_cpu.temperature != 0)
                cpuTemp.Text = "Temp: " + _cpu.temperature.ToString() + "°C";
            else
                cpuTemp.Text = "Temp: N/A";
            cpuUsage.Text = "Usage: "+ Math.Round(_cpu.usage * 100,2) + "%";
            try
            {
                if (_cpu.fanSpeed[0] != 0)
                    cpuFanSpeed.Text = "Fan: " + _cpu.fanSpeed[0].ToString() + "RPM";
                else
                    cpuFanSpeed.Text = "Fan: N/A";
            }
            catch (Exception)
            {
                cpuFanSpeed.Text = "Fan: N/A";
            }
           

         

            //gpu
            if (_gpu.componentName != "")
                gpuName.Text = _gpu.componentName.Trim(); 
            else
                gpuName.Text = "GPU";

            if (_gpu.temperature != 0)
                gpuTemp.Text = "Temp: " + _gpu.temperature.ToString() + "°C";
            else
                gpuTemp.Text = "Temp: N/A";
            gpuUsage.Text = "Usage: " + _gpu.usage.ToString() + "%";
            gpuVRam.Text = "VramTotal: " + bytesToGigabytes(_gpu.vramTotal) + "GB";

            //ram
            if (_ram.componentName != "" || _ram.componentName == null)
                ramName.Text = _ram.componentName.Trim(); 
            else
                ramName.Text = "RAM";
            ramUsage.Text = "Usage: " + Math.Round(_ram.getUsage() * 100,2) + "%";
            ramAvailable.Text = "Available: " + bytesToGigabytes(_ram.getMemoryAvailable()) + "GB";
            ramTotal.Text = "Total: " + bytesToGigabytes(_ram.getMemoryTotal()) + "GB";

            //disk
            if (_disk.componentName != "")
                diskName.Text = _disk.componentName.Trim();
            else
                diskName.Text = "Disk";
            if (_disk.temperature != 0)
                diskTemp.Text = "Temp: " + _disk.temperature.ToString() + "°C";
            else
                diskTemp.Text = "Temp: N/A";
            diskUsage.Text = "Usage: "+_disk.usage.ToString() + "%";
            //convert to GB
            diskAvailable.Text = "Available: "+ bytesToGigabytes(_disk.availableCapacity) + "GB";
            diskTotal.Text = "Total: " + bytesToGigabytes(_disk.capacity) + "GB";
           
        }
        private double bytesToGigabytes(long bytes)
        {
            // Convert to gigabytes without rounding
            double gigabytes = bytes / (1024.0 * 1024.0 * 1024.0);
            // Round to two decimal places
            return Math.Round(gigabytes * 100.0) / 100.0;
        }
        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            try
            {
               string data = await _client.RequestDataAsync();
               Update(JArray.Parse(data));
               setFields();

            }
            catch (Exception)
            {
                _client.Disconnect();
                var newPage = new MainPage("Disconnected from server");
                var animation = new Animation(v => newPage.Opacity = v, 0, 1);

                animation.Commit(newPage, "FadeAnimation", length: 500, easing: Easing.Linear);
                await Navigation.PushAsync(newPage);
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            }

        }

        //disconnect from server button
        private void Button_Clicked(object sender, EventArgs e)
        {
            _client.Disconnect();
            var newPage = new MainPage("Disconnected from server");
            var animation = new Animation(v => newPage.Opacity = v, 0, 1);

            animation.Commit(newPage, "FadeAnimation", length: 500, easing: Easing.Linear);
            Navigation.PushAsync(newPage);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

        }

    }
}