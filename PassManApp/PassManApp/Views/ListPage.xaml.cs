using Newtonsoft.Json;
using PassManApp.API;
using PassManApp.Models;
using PassManApp.Services;
using PassManApp.ViewModels;
using PassManApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassManApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
		public ApiServices apiServices;
		public List<PasswordData> data { get; set; }
		public ListPage()
		{
			apiServices = new ApiServices();

			this.InitializeComponent();
			this.LoadData();
			//listView.ItemsSource = apiServices.GetDataApi();
			//base.BindingContext = model.data;
		}

		async void LoadData()
		{
			var model = new ListViewModel();
			listView.ItemsSource = await model.GetData();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			this.LoadData();
			//base.BindingContext = new ListViewModel();
		}
		private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var data = e.Item as PasswordData;
			base.Navigation.PushAsync(new DetailListView(data));
		}

		private void New_Clicked(object sender, EventArgs e)
		{
			base.Navigation.PushAsync(new NewItemPage());
		}

		private void Settings_Clicked(object sender, EventArgs e)
		{
			base.Navigation.PushAsync(new SettingsPage());
		}

		private void Generator_Clicked(object sender, EventArgs e)
		{
			base.Navigation.PushAsync(new GeneratorPage());
		}

		private void About_Clicked(object sender, EventArgs e)
		{
			base.Navigation.PushAsync(new AboutPage());
		}
	}
}