using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3_POMS.Pages.Lab3_Fragments
{
    public delegate void ChangeEventHandler();

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_ChangeSpace : ContentView
    {
        public event ChangeEventHandler BackEvent;
        public event ChangeEventHandler ForwardEvent;
        public View_ChangeSpace()
        {
            InitializeComponent();
        }

        private void Button_Forward_Clicked(object sender, EventArgs e)
        {
            ForwardEvent?.Invoke();
        }

        private void Button_Back_Clicked(object sender, EventArgs e)
        {
            BackEvent?.Invoke();
        }
    }
}