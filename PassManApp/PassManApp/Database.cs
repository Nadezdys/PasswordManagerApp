using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using PassManApp.Models;
using SQLite;

namespace PassManApp
{
	public class Database
	{
		public static string PassKey { get; set; }
		public Database(string dbPath)
		{
			this._database = new SQLiteConnection(dbPath, true);
			this._database.CreateTable<DataClass>(CreateFlags.None);
		}

		public List<DataClass> GetData()
		{
			List<DataClass> decryptedList = this._database.Table<DataClass>().ToList();
			foreach(DataClass data in decryptedList)
			{
				data.Title = Encryption.Decrypt(data.Title, PassKey);
				data.Username = Encryption.Decrypt(data.Username, PassKey);
				data.Password = Encryption.Decrypt(data.Password, PassKey);
				data.Webpage = Encryption.Decrypt(data.Webpage, PassKey);
				data.Note = Encryption.Decrypt(data.Note, PassKey);
			}
			return decryptedList;
		}

		public int SaveData(DataClass data)
		{
			DataClass encryptedData = new DataClass()
			{
				Title = Encryption.Encrypt(data.Title, PassKey),
				Username = Encryption.Encrypt(data.Username, PassKey),
				Password = Encryption.Encrypt(data.Password, PassKey),
				Webpage = Encryption.Encrypt(data.Webpage, PassKey),
				Note = Encryption.Encrypt(data.Note, PassKey)
			};
			return this._database.Insert(encryptedData);
		}

		public int DeleteData(DataClass data)
		{
			DataClass encryptedData = new DataClass()
			{
				Title = Encryption.Encrypt(data.Title, PassKey),
				Username = Encryption.Encrypt(data.Username, PassKey),
				Password = Encryption.Encrypt(data.Password, PassKey),
				Webpage = Encryption.Encrypt(data.Webpage, PassKey),
				Note = Encryption.Encrypt(data.Note, PassKey)
			};
			return this._database.Delete(encryptedData);
		}

		public int AlterData(DataClass data)
		{
			DataClass encryptedData = new DataClass()
			{
				Title = Encryption.Encrypt(data.Title, PassKey),
				Username = Encryption.Encrypt(data.Username, PassKey),
				Password = Encryption.Encrypt(data.Password, PassKey),
				Webpage = Encryption.Encrypt(data.Webpage, PassKey),
				Note = Encryption.Encrypt(data.Note, PassKey)
			};
			return this._database.Update(encryptedData);
		}

		private readonly SQLiteConnection _database;
	}
}

