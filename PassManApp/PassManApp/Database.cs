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
			this._database.CreateTable<PasswordData>(CreateFlags.None);
			
		}

		public List<PasswordData> GetData()
		{
			List<PasswordData> decryptedList = this._database.Table<PasswordData>().ToList();
			foreach(PasswordData data in decryptedList)
			{
				//data.Title = Encryption.Decrypt(data.Title, PassKey);
				//data.Username = Encryption.Decrypt(data.Username, PassKey);
				data.Password = Encryption.Decrypt(data.Password, PassKey);
				//data.Webpage = Encryption.Decrypt(data.Webpage, PassKey);
				//data.Note = Encryption.Decrypt(data.Note, PassKey);
			}
			return decryptedList;
		}

		public int SaveData(PasswordData data)
		{

			PasswordData encryptedData = new PasswordData()
			{
				//Title = Encryption.Encrypt(data.Title, PassKey),
				Title = data.Title,
				//Username = Encryption.Encrypt(data.Username, PassKey),
				Username = data.Username,
				Password = Encryption.Encrypt(data.Password, PassKey),
				//Webpage = Encryption.Encrypt(data.Webpage, PassKey),
				Webpage = data.Webpage,
				//Note = Encryption.Encrypt(data.Note, PassKey)
				Note = data.Note
			};
			return this._database.Insert(encryptedData);
		}

		public int DeleteData(PasswordData data)
		{
			PasswordData encryptedData = new PasswordData()
			{
				//Title = Encryption.Encrypt(data.Title, PassKey),
				Title = data.Title,
				//Username = Encryption.Encrypt(data.Username, PassKey),
				Username = data.Username,
				Password = Encryption.Encrypt(data.Password, PassKey),
				//Webpage = Encryption.Encrypt(data.Webpage, PassKey),
				Webpage = data.Webpage,
				//Note = Encryption.Encrypt(data.Note, PassKey)
				Note = data.Note
			};
			return this._database.Delete(encryptedData);
		}

		public int AlterData(PasswordData data)
		{
			PasswordData encryptedData = new PasswordData()
			{
				//Title = Encryption.Encrypt(data.Title, PassKey),
				Title = data.Title,
				//Username = Encryption.Encrypt(data.Username, PassKey),
				Username = data.Username,
				Password = Encryption.Encrypt(data.Password, PassKey),
				//Webpage = Encryption.Encrypt(data.Webpage, PassKey),
				Webpage = data.Webpage,
				//Note = Encryption.Encrypt(data.Note, PassKey)
				Note = data.Note
			};
			return this._database.Update(encryptedData);
		}

		private readonly SQLiteConnection _database;
	}
}

