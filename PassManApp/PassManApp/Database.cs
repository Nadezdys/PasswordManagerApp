using System;
using System.Collections.Generic;
using System.Text;
using PassManApp.Models;
using SQLite;

namespace PassManApp
{
	public class Database
	{
		
		public Database(string dbPath)
		{
			this._database = new SQLiteConnection(dbPath, true);
			this._database.CreateTable<DataClass>(CreateFlags.None);
		}
		public List<DataClass> GetData()
		{
			return this._database.Table<DataClass>().ToList();
		}

		public int SaveData(DataClass data)
		{
			return this._database.Insert(data);
		}

		public int DeleteData(DataClass data)
		{
			return this._database.Delete(data);
		}

		public int AlterData(DataClass data)
		{
			return this._database.Update(data);
		}

		private readonly SQLiteConnection _database;
	}
}

