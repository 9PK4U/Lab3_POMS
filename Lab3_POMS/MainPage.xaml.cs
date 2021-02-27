using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace Lab3_POMS
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            SubscribeHandlerBrowser();
            
        }

        private void SubscribeHandlerBrowser()
        {
            MessagingCenter.Unsubscribe<string>(this, "BrowserIntent");
            MessagingCenter.Subscribe<string>(this, "BrowserIntent", (value) =>
            {
                Navigation.PushAsync(new Pages.Lab5_Fragments.PageHandler(value));
            });
        }
        private void InitPreferences()
        {
            var pathDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");
            var pathSrvsFl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Service.txt");
            Preferences.Set("PATH_DATABASE", pathDB);
            Preferences.Set("PATH_SERVICE_FILE", pathSrvsFl);
        }
    }
    
}
