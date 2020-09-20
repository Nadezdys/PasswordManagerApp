using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassManApp.Views.MDPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
		public MasterPage()
		{
			this.InitializeComponent();
			base.Master = new MasterPageMaster();
			base.Detail = new NavigationPage(new MasterPageDetail());
			this.MPage.ListView.ItemSelected += this.ListView_ItemSelected;
		}
		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			MasterPageMasterMenuItem masterPageMasterMenuItem = e.SelectedItem as MasterPageMasterMenuItem;
			bool flag = masterPageMasterMenuItem == null;
			if (!flag)
			{
				Page page = (Page)Activator.CreateInstance(masterPageMasterMenuItem.TargetType);
				page.Title = masterPageMasterMenuItem.Title;
				base.Detail = new NavigationPage(page);
				base.IsPresented = false;
				this.MPage.ListView.SelectedItem = null;
			}
		}
	}
}