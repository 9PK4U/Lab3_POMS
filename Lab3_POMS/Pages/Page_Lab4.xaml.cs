using Lab3_POMS.Classes;
using Lab3_POMS.Classes.Lab4;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.IO;
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

            var db = new DataBase();
            var list = db.GetHistoryItems();
    
        historyList.ItemsSource = list;

            this.BindingContext = this;
        }
        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as HistoryItem;
            if (selectedItem != null)
                await DisplayAlert(selectedItem.Date, $"{selectedItem.ToString()}\n{selectedItem.DetailText}", "OK");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var db = new DataBase();
            db.remove();
            var list = db.GetHistoryItems();

            historyList.ItemsSource = list;
        }
    }
}
