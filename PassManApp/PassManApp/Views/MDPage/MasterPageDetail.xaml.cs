using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassManApp.Views.MDPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageDetail : ContentPage
    {
        public MasterPageDetail()
        {
            InitializeComponent();
            Database.PassKey = "default";
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            Database.PassKey = masterKeyEntry.Text;
        }
    }
}