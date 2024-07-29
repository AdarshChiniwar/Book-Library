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
    public class BookDetailPageViewModel : BaseViewModel
    {

        #region Sqlite
        Isqlite Isqlite;
        SQLite.SQLiteConnection sqliteConnection;
        #endregion

        #region Properties
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

        public ICommand SaveCmd { get; set; }
        #endregion

        #region Constructor
        public BookDetailPageViewModel()
        {
            Isqlite = DependencyService.Get<Isqlite>();
            sqliteConnection = Isqlite.GetConnection();
            SaveCmd = new Command(Save);
        }
        #endregion

        #region Private Functions
        private async void Save()
        {
            try
            {
                if(string.IsNullOrEmpty(TitleText) || string.IsNullOrEmpty(AuthorText) ||
                    string.IsNullOrEmpty(PriceText))
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "Error , Fields cannot be empty", "OK");
                }
                else
                {
                    BookModel bookModel = new BookModel()
                    {

                        Title = TitleText,
                        Author = AuthorText,
                        Price = PriceText
                    };
                    int result = sqliteConnection.Insert(bookModel);
                    if (result == 1)
                    {
                        await Application.Current.MainPage.DisplayAlert("Info", "Congratulations , Data inserted Successfully", "OK");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Registration Failed!!!", "Please try again", "ERROR");
                    }
                }
              
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                throw;
            }
        }
        #endregion
    }
}
