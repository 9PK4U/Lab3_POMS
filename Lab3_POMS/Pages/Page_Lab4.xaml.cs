using Lab3_POMS.Classes.Lab4;
using System.Collections.Generic;
using System.Collections.ObjectModel;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3_POMS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Lab4 : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Page_Lab4()
        {
            InitializeComponent();
            historyList.ItemsSource = (List<HistoryItem>)App.Current.Resources["list"];
            this.BindingContext = this;
        }
        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as HistoryItem;
            if (selectedItem != null)
                await DisplayAlert(selectedItem.Date, $"{selectedItem.Text}\n{selectedItem.DetailText}", "OK");
        }
    }
}
