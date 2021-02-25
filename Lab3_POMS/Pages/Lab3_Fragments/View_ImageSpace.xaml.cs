using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3_POMS.Pages.Lab3_Fragments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_ImageSpace : ContentView
    {
        int numberImage = 1;
        public void BackChangeImage()
        {
            ForwardChangeImage();
        }
        public void ForwardChangeImage()
        {
            if (numberImage == 1)
            {
                ImageControl.Source = "Image2.png";
                numberImage = 2;
            }
            else
            {
                ImageControl.Source = "Image1.jpg";
                numberImage = 1;
            }    
        }
        public View_ImageSpace()
        {
            InitializeComponent();
        }
    }
}