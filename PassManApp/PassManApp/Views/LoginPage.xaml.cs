
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassManApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Database.PassKey = "default";
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            
            Database.PassKey = masterKeyEntry.Text;
            if (Database.PassKey == "heslo")
                base.Navigation.PushAsync(new ListPage());
            else
                DisplayAlert("Heslo", "Nesprávné heslo", "OK");
            
        }
    }
}