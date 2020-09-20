using PassManApp.Models;
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
		public NewItemPage()
		{
			this.InitializeComponent();
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
				DataClass data = new DataClass
				{
					Title = this.nameEntry.Text,
					Username = this.usernameEntry.Text,
					Password = this.passwordEntry.Text,
					Webpage = this.webEntry.Text,
					Note = this.noteEntry.Text
				};
				App.Database.SaveData(data);
				base.Navigation.PopAsync();
			}
		}
	}
}