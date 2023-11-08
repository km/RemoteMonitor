using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
namespace RemoteMonitor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
          //  MainPage = new Monitor(JArray.Parse("[{\"cores\":6,\"speed\":0,\"currentSpeed\":[0,0,0,0,0,0,0,0,0,0,0,0],\"fanSpeeds\":[],\"componentName\":\"AMD Ryzen 5 5500U with Radeon Graphics         \",\"componentType\":\"CPU\",\"lastUpdated\":1678824047922,\"temperature\":0.0,\"usage\":0.045587280986372485}, [{\"vramTotal\":536870912,\"componentName\":\"AMD Radeon(TM) Graphics\",\"componentType\":\"GPU\",\"lastUpdated\":1678824046679,\"temperature\":0.0,\"usage\":0.0}], {\"memoryTotal\":7908114432,\"memoryAvailable\":630198272,\"componentType\":\"Ram\",\"lastUpdated\":1678824047936,\"temperature\":0.0,\"usage\":0.0}, [{\"capacity\":256052966400,\"availableCapacity\":22615560192,\"componentName\":\"KINGSTON OM8PDP3256B-AI1 (Standard disk drives)\",\"componentType\":\"Disk\",\"lastUpdated\":1678824046679,\"temperature\":0.0,\"usage\":0.0}]]\r\n"));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
