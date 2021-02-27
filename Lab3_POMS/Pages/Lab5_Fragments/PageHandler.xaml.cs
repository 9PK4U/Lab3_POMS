using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3_POMS.Pages.Lab5_Fragments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHandler : ContentPage
    {
        public PageHandler(string text)
        {
            InitializeComponent();

            LabelText.Text = text;
            
        }
    }
}