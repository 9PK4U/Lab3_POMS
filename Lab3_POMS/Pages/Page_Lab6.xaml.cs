using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3_POMS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Lab6 : ContentPage
    {
        public Page_Lab6()
        {
            InitializeComponent();
            entryText.Placeholder = Xamarin.Essentials.Preferences.Get("SAVE_ENTRY_TEXT", entryText.Text);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string filename = "file.txt";



            if (String.IsNullOrEmpty(Path.Combine(folderPath, filename))) return;
            if (!File.Exists(Path.Combine(folderPath, filename))) return;

            textFile.Text = File.ReadAllText(Path.Combine(folderPath, filename));


            var text = entryText.Text;
            Xamarin.Essentials.Preferences.Set("SAVE_ENTRY_TEXT", text);

        }
    }
}