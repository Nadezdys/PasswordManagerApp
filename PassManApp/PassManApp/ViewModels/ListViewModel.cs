using Newtonsoft.Json;
using PassManApp.Models;
using PassManApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PassManApp.ViewModels
{
	public class ListViewModel: INotifyPropertyChanged
	{
        WebAPIService webAPIService;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PasswordData> items;

        #region Constructor
        public ListViewModel()
        {
            webAPIService = new WebAPIService();
            items = new ObservableCollection<PasswordData>();
         
        }
        #endregion

        #region Methods 
        public async Task<ObservableCollection<PasswordData>> GetData()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://192.168.8.113:45455/api/PasswordData");
            var data = JsonConvert.DeserializeObject<ObservableCollection<PasswordData>>(response);
           
            return data;
        }
        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        //public List<DataClass> data { get; set; }

		/*public ListViewModel()
		{

			this.data = App.Database.GetData();
		}*/
	}
}
