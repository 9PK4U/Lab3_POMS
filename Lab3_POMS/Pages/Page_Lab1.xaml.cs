using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Lab3_POMS.RESX.Lab1;

namespace Lab3_POMS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Lab1 : ContentPage
    {
        public Page_Lab1()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            float growth = Convert.ToSingle(gInput.Text) / 100;
            float weight = Convert.ToSingle(wInput.Text);

            float result = IndexCalculation(growth, weight);

            if (growth == 0 || weight == 0)
            {
                DisplayAlert("0", "0", "Ок");
                return;
            }

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
            DisplayAlert(Resource.resultText, Resource.yourIndexText + " " + Convert.ToInt32(result).ToString() + "\n " + Resource.prefixYourIndex + " " + res, "Ok");


        }

        private void ButtonWhat_Clicked(object sender, EventArgs e)
        {
            DisplayAlert(Resource.whatText, Resource.infoText, "OK");
        }

        private float IndexCalculation(float growth, float weight)
        {
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
    }
}