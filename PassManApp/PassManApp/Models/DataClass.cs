using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PassManApp.Models
{
	public class DataClass
	{
		[PrimaryKey]
		[AutoIncrement]
		public int ID { get; set; }
		public string Title { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Webpage { get; set; }
		public string Note { get; set; }
	}
}
