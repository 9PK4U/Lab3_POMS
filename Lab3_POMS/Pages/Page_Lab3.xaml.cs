using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3_POMS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Lab3 : TabbedPage
    {
        public Page_Lab3()
        {
            InitializeComponent();
        }

        private void View_ChangeSpace_BackEvent()
        {
            ImageSpace.BackChangeImage();
        }

        private void View_ChangeSpace_ForwardEvent()
        {
            ImageSpace.ForwardChangeImage();
        }


    }
}