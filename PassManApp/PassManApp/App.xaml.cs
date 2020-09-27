using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PassManApp.Views.MDPage;
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
					App.database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db3"));
				}
				return App.database;
			}
		}
		public App()
		{
			this.InitializeComponent();
			base.MainPage = new NavigationPage(new MasterPage());
		}
		protected override void OnStart()
		{
		}
		protected override void OnSleep()
		{
		}
		protected override void OnResume()
		{
		}
	}
}
