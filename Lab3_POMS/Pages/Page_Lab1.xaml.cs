using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Lab3_POMS.RESX.Lab1;
using Lab3_POMS.Classes.Lab4;


namespace Lab3_POMS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Lab1 : ContentPage
    {
        Classes.DataBase db = new Classes.DataBase();
        public Page_Lab1()
        {

            InitializeComponent();
            App.Current.Resources.Add("list", new List<HistoryItem>());

        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            float growth = Convert.ToSingle(gInput.Text);
            float weight = Convert.ToSingle(wInput.Text);

            float result = IndexCalculation(growth, weight);

            if (growth == 0 || weight == 0)
            {
                DisplayAlert("0", "0", "Ок");
                return;
            }

            string detailResult = DetailResult(result);
            DisplayAlert(Resource.resultText, Resource.yourIndexText + " " + Convert.ToInt32(result).ToString() + "\n " + Resource.prefixYourIndex + " " + detailResult, "Ok");

            //((List<HistoryItem>)App.Current.Resources["list"]).Add(new HistoryItem(weight, growth, result,detailResult));
            AddToDataBase(weight, growth, result, detailResult);
        }

        private static string DetailResult(float result)
        {
            string res;
            if (result > 25)
            {
                res = Resource.hardMassText;
            }
            else if (result < 20)
            {
                res = Resource.easyMassText;
            }
            else
            {
                res = Resource.normaMasslText;
            }

            return res;
        }

        private void ButtonWhat_Clicked(object sender, EventArgs e)
        {
            DisplayAlert(Resource.whatText, Resource.infoText, "OK");
        }

        private float IndexCalculation(float growth, float weight)
        {
            growth /= 100;
            float res = weight / (growth * growth);
            return res;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            changeOrintationMaket(height < width);
        }
        private void changeOrintationMaket(bool isHorizontal)
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                inputLayout.Orientation = isHorizontal ? StackOrientation.Horizontal : StackOrientation.Vertical;
            }
            else
            {
                inputLayout.Orientation = StackOrientation.Horizontal;
            }

        }



        private void HistoryItem_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new Page_Lab4());
        }


        private void AddToDataBase(float growth, float weight, float result, string detailResult)
        {
            var item = new HistoryItem() { Weight = weight, Growth = growth, IBM = result, DetailText = detailResult, Date = DateTime.Now.ToString() };
            //var item = HistoryItem.Builder(weight, growth, result, detailResult);
            db.AddItem(item);

        }
    }

}