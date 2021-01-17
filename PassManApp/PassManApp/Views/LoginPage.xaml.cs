
using PassManApp.Models;
using PassManApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        WebAPIService service;
        ObservableCollection<LoginData> data;
        public LoginPage()
        {
            InitializeComponent();
            //Database.PassKey = "default";
            service = new WebAPIService();
            data = new ObservableCollection<LoginData>();
            FillList();
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            bool flag = string.IsNullOrEmpty(this.usernameEntry.Text) || string.IsNullOrEmpty(this.masterKeyEntry.Text);
            if (flag)
            {
                await base.DisplayAlert("Alert", "Vyplnte všechna povinná pole", "OK");
            }
            
            if (ValidateUsername()&&ValidatePassword())
                await base.Navigation.PushAsync(new ListPage());
            else
                await DisplayAlert("Chyba", "Nesprávné údaje", "OK");
            
        }

        private async void FillList()
        {
            this.data = await this.service.RefreshLoginDataAsync();
        }

        private bool ValidateUsername()
        {
            foreach(LoginData d in this.data)
            {
                if(d.Username == usernameEntry.Text)
                {
                    return true;
                }
            }
            return false;
        }
        private bool ValidatePassword()
        {
            foreach (LoginData d in this.data)
            {
                if (d.Password == masterKeyEntry.Text)
                {
                    return true;
                }
            }
            return false;
        }
    }
}