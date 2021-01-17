using PassManApp.Models;
using PassManApp.Services;
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
    public partial class DetailListView : ContentPage
    {
		private PasswordData data;
		WebAPIService service;
		public DetailListView(PasswordData data)
			{
				this.InitializeComponent();
				service = new WebAPIService();
				this.data = data;
				this.nameEntry.Text = data.Title;
				this.usernameEntry.Text = data.Username;
				this.passwordEntry.Text = data.Password;
				this.webEntry.Text = data.Webpage;
				this.noteEntry.Text = data.Note;
			}

			private void Delete_Clicked(object sender, EventArgs e)
			{
			//App.Database.DeleteData(this.data);
			service.DeleteDataApi(this.data);
				base.Navigation.PopAsync();
			}

			private void saveButton_Clicked(object sender, EventArgs e)
			{
				bool flag = string.IsNullOrEmpty(this.nameEntry.Text) || string.IsNullOrEmpty(this.usernameEntry.Text) || string.IsNullOrEmpty(this.passwordEntry.Text) || string.IsNullOrEmpty(this.webEntry.Text);
				if (flag)
				{
					base.DisplayAlert("Alert", "Vyplnte všechna povinná pole", "OK");
				}
				else
				{
					this.data.Title = this.nameEntry.Text;
					this.data.Username = this.usernameEntry.Text;
					this.data.Password = this.passwordEntry.Text;
					this.data.Webpage = this.webEntry.Text;
					this.data.Note = this.noteEntry.Text;
				//App.Database.AlterData(this.data);
				service.AlterDataApi(this.data);
					base.DisplayAlert("Alert", "Data byla uložena", "OK");
				}
				base.Navigation.PopAsync();
			}
	}
}