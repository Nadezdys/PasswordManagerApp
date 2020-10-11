using PassManApp.Models;
using PassManApp.ViewModels;
using PassManApp.Views;
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
    public partial class ListPage : ContentPage
    {
		public List<DataClass> data { get; set; }
		public ListPage()
		{
			this.InitializeComponent();
			var model = new ListViewModel();
			listView.ItemsSource = model.data;
			//base.BindingContext = model.data;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var model = new ListViewModel();
			listView.ItemsSource = model.data;
			//base.BindingContext = new ListViewModel();
		}
		private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var data = e.Item as DataClass;
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