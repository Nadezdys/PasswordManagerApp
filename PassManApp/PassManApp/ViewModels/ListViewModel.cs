using PassManApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassManApp.ViewModels
{
	internal class ListViewModel
	{
		public List<DataClass> data { get; set; }

		public ListViewModel()
		{
			this.data = App.Database.GetData();
		}
	}
}
