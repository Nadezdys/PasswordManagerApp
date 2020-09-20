using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PassManApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
		public MainPage()
		{
			this.InitializeComponent();
		}

		private void List_Clicked(object sender, EventArgs e)
		{
			base.Navigation.PushAsync(new ListPage());
		}
	}
}
