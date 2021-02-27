using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Lab3_POMS.Pages.Lab5_Fragments
{ 

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageServise : ContentPage
    {
        INotificationManager notificationManager;

        public PageServise()
        {
            InitializeComponent();

            notificationManager = DependencyService.Get<INotificationManager>();

            MessagingCenter.Unsubscribe<string>(this, "counterValue");
            MessagingCenter.Subscribe<string>(this, "counterValue", (value) =>
            {
                label.Text = value;
            });

        }

        private void StartService(object sender, EventArgs e)
        {
            MessagingCenter.Send<string>("start", "BgService");
        }

        private void StopService(object sender, EventArgs e)
        {
            MessagingCenter.Send<string>("stop", "BgService");
        }
    }
}