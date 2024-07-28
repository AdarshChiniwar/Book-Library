using App1;
using App1.ViewModels;
using MyBookLibrary.Contrcts;
using MyBookLibrary.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyBookLibrary.ViewModels
{
    public class BookListPageViewModel : BaseViewModel
    {
        #region Global Variables
        SQLite.SQLiteConnection sqliteConnection;
        #endregion

        #region Properties
        private ObservableCollection<BookModel> bookLists;
        public ObservableCollection<BookModel> BookLists
        {
            get { return bookLists; }
            set { bookLists = value; OnPropertyChanged(nameof(BookLists)); }
        }

        public ICommand DeleteRecordCmd { get; set; }
        public ICommand ModifyRecordCmd { get; set; }
        #endregion
        #region Constructor

        public BookListPageViewModel()
        {
            sqliteConnection = DependencyService.Get<Isqlite>().GetConnection();
            BookLists = new ObservableCollection<BookModel>();
            DeleteRecordCmd = new Command<BookModel>(DeleteRecord);
            ModifyRecordCmd = new Command<BookModel>(ModifyRecord);
            LoadBookList();
        }

        #endregion

        #region Functions
        private async void ModifyRecord(BookModel model)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new StoreAdminPage(model));
        }

        private async void DeleteRecord(BookModel model)
        {
            try
            {
              bool result =  await Application.Current.MainPage.DisplayAlert("Info", "Are you sure you want to delete the record?", "OK","Cancel");
                if(result)
                {
                    sqliteConnection.Delete<BookModel>(model.Id);
                    LoadBookList();
                }
            
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
          
           
        }
        private async void LoadBookList()
        {
            try
            {
                BookLists.Clear();
                var details = (from x in sqliteConnection.Table<BookModel>() select x).ToList();
                foreach (var item in details)
                {
                    BookLists.Add(item);
                }
                if(BookLists.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "No records available!", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
               
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        #endregion
    }
}
