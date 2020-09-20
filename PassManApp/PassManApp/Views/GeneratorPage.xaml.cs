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
    public partial class GeneratorPage : ContentPage
    {
		public bool Switch1 { get; set; }
		public bool Switch2 { get; set; }
		public bool Switch3 { get; set; }
		public bool Switch4 { get; set; }
		public GeneratorPage()
		{
			this.InitializeComponent();
			this.Switch1 = false;
			this.Switch2 = false;
			this.Switch3 = false;
			this.Switch4 = false;
		}
		private void switch1_Toggled(object sender, ToggledEventArgs e)
		{
			bool value = e.Value;
			if (value)
			{
				this.Switch1 = true;
			}
			else
			{
				this.Switch1 = false;
			}
		}
		private void switch2_Toggled(object sender, ToggledEventArgs e)
		{
			bool value = e.Value;
			if (value)
			{
				this.Switch2 = true;
			}
			else
			{
				this.Switch2 = false;
			}
		}
		private void switch3_Toggled(object sender, ToggledEventArgs e)
		{
			bool value = e.Value;
			if (value)
			{
				this.Switch3 = true;
			}
			else
			{
				this.Switch3 = false;
			}
		}
		private void switch4_Toggled(object sender, ToggledEventArgs e)
		{
			bool value = e.Value;
			if (value)
			{
				this.Switch4 = true;
			}
			else
			{
				this.Switch4 = false;
			}
		}
		private void generateButton_Clicked(object sender, EventArgs e)
		{
			Random random = new Random();
			string text = "";
			int num = 0;
			int.TryParse(this.countEntry.Text, out num);
			bool flag = num == 0;
			if (flag)
			{
				base.DisplayAlert("Alert", "Zadejte počet znaků.", "OK");
			}
			else
			{
				bool flag2 = !this.Switch1 && !this.Switch2 && !this.Switch3 && !this.Switch4;
				if (flag2)
				{
					base.DisplayAlert("Alert", "Vyberte minimálně jednu možnost.", "OK");
				}
				else
				{
					bool flag3 = this.Switch1;
					if (flag3)
					{
						text += "abcdefghijklmnopqrstuvxyz";
					}
					bool flag4 = this.Switch2;
					if (flag4)
					{
						text += "ABCDEFGHIJKLMNOPQRSTUVXYZ";
					}
					bool flag5 = this.Switch3;
					if (flag5)
					{
						text += "0123456789";
					}
					bool flag6 = this.Switch4;
					if (flag6)
					{
						text += " !”#$%&’()*+,-./:;<=>?@][^_`{}|~";
					}
					string text2 = new string((from s in Enumerable.Repeat<string>(text, num)
											   select s[random.Next(s.Length)]).ToArray<char>());
					this.passwordEntry.Text = text2;
				}
			}
		}
	}
}