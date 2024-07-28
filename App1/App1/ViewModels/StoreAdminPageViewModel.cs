using App1;
using App1.ViewModels;
using MyBookLibrary.Contrcts;
using MyBookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyBookLibrary.ViewModels
{
    public class StoreAdminPageViewModel : BaseViewModel
    {
        #region Global Variables
        SQLite.SQLiteConnection sqliteConnection;
        #endregion

        #region Properties
        private string idtext;
        public string Idtext
        {
            get { return idtext; }
            set { idtext = value; OnPropertyChanged(nameof(Idtext)); }
        }

        private string titleText;
        public string TitleText
        {
            get { return titleText; }
            set { titleText = value; OnPropertyChanged(nameof(TitleText)); }
        }

        private string authorText;
        public string AuthorText
        {
            get { return authorText; }
            set { authorText = value; OnPropertyChanged(nameof(AuthorText)); }
        }

        private string priceText;
        public string PriceText
        {
            get { return priceText; }
            set { priceText = value; OnPropertyChanged(nameof(PriceText)); }
        }
        public ICommand UpdateCmd { get; set; }
        #endregion

        #region Constructor
        public StoreAdminPageViewModel(BookModel bookModel)
        {
            Idtext = bookModel.Id.ToString();
            UpdateCmd = new Command(UpdateRecord);
            sqliteConnection = DependencyService.Get<Isqlite>().GetConnection();
        }


        #endregion

        #region Functions
        private async void UpdateRecord()
        {
            if (string.IsNullOrEmpty(TitleText) ||
                  string.IsNullOrEmpty(AuthorText) ||
                  string.IsNullOrEmpty(PriceText)
                  )
            {
                await Application.Current.MainPage.DisplayAlert("Info", "Fields cannot be empty", "OK");
            }
            else
            {
                BookModel bookModel = new BookModel()
                {
                    Id = Convert.ToInt32(Idtext),
                    Title = TitleText,
                    Author = AuthorText,
                    Price = PriceText
                };
                try
                {
                    sqliteConnection.Update(bookModel);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new BookListPage());
                }
                catch (Exception ex) 
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
              
            }
        }

        #endregion
    }
}
