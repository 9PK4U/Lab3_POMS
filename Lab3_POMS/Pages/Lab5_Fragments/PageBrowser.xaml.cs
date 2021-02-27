using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3_POMS.Pages.Lab5_Fragments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageBrowser : ContentPage
    {
        public PageBrowser()
        {
            InitializeComponent();
        }

        private async void OpenLink(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync(linkEntry.Text, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                await DisplayAlert("Ошибка", "Ссылка не действительна", "ОК");
            }
            
        }
    }
}