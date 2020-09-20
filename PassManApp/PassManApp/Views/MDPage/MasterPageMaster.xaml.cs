﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassManApp.Views.MDPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageMaster : ContentPage
    {
        public ListView ListView;
   
        public MasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menuItem = e.Item as MasterPageMasterMenuItem;
            if (menuItem.Id == 0)
                base.Navigation.PushAsync(new ListPage());
            else if (menuItem.Id == 1)
                base.Navigation.PushAsync(new GeneratorPage());
        }

        class MasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterPageMasterMenuItem> MenuItems { get; set; }

            public MasterPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterPageMasterMenuItem>(new[]
                {
                    new MasterPageMasterMenuItem { Id = 0, Title = "Seznam hesel" },
                    new MasterPageMasterMenuItem { Id = 1, Title = "Generátor" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}