using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace PassManApp
{
    public partial class App : Application
    {
		static Database database;

		public static Database Database
		{
			get
			{
				bool flag = App.database == null;
				if (flag)
				{
					App.database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbnew.db3"));
				}
				return App.database;
			}
		}
		public App()
		{
			this.InitializeComponent();
			base.MainPage = new NavigationPage(new LoginPage());
		}
		protected override void OnStart()
		{
			Application.Current.MainPage = new NavigationPage(new LoginPage());
		}
		protected override void OnSleep()
		{
		}
		protected override async void OnResume()
		{
			var nav = MainPage.Navigation;

			await nav.PopToRootAsync(true);

			await nav.PushAsync(new LoginPage());

		}
	}
	
}
