using PassManApp.API;
using PassManApp.Models;
using PassManApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassManApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
		IMyAPI myAPI;
		WebAPIService service;
		public NewItemPage()
		{
			this.InitializeComponent();
			//myAPI = RestService.For<IMyAPI>("http://192.168.8.113:45455");
			service = new WebAPIService();

		}
		private async void saveButton_Clicked(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.nameEntry.Text) || string.IsNullOrEmpty(this.usernameEntry.Text) || string.IsNullOrEmpty(this.passwordEntry.Text) || string.IsNullOrEmpty(this.webEntry.Text);
			if (flag)
			{
				await base.DisplayAlert("Alert", "Vyplnte všechna povinná pole", "OK");
			}
			else
			{
				PasswordData data = new PasswordData
				{
					Title = this.nameEntry.Text,
					Username = this.usernameEntry.Text,
					Password = this.passwordEntry.Text,
					Webpage = this.webEntry.Text,
					Note = this.noteEntry.Text
				};

				service.AddDataApi(data);
				//var result = await myAPI.PostData(data);
				//await base.DisplayAlert("Alert", result, "OK");
				//App.Database.SaveData(data);
				await base.Navigation.PopAsync();
			}
		}
	}
}