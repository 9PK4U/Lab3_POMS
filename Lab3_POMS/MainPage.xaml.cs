using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
    }
    
}
