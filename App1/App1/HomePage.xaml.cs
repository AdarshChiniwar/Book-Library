using App1.Services;
using System;
using Xamarin.Forms;
using App1;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using MyBookLibrary.Models;
using MyBookLibrary.Contrcts;
using System.IO;

namespace App1
{
    public partial class HomePage : ContentPage
    {
        private ObservableCollection<ImageModel> imageCollection;
        public ObservableCollection<ImageModel> ImageCollection 
        {
            get { return imageCollection; }
            set { imageCollection = value; OnPropertyChanged(nameof(ImageCollection)); }
        }
        SQLite.SQLiteConnection sqliteConnection;
        Isqlite Isqlite = DependencyService.Get<Isqlite>();
        public HomePage()
        {
            InitializeComponent();
            BindingContext = this;
            ImageCollection = new ObservableCollection<ImageModel>();
            ImageCollection.Add(new ImageModel { CauroselImage = "1.png" });
            ImageCollection.Add(new ImageModel { CauroselImage = "2.webp" });
            ImageCollection.Add(new ImageModel { CauroselImage = "3.png" });
            ImageCollection.Add(new ImageModel { CauroselImage = "4.webp" });
            ImageCollection.Add(new ImageModel { CauroselImage = "5.jpg" });

            sqliteConnection = DependencyService.Get<Isqlite>().GetConnection();
            CreateTables();


        }

        private void CreateTables()
        {
            sqliteConnection.CreateTable<BookModel>();
        }
        private async void EnterBookDetails_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookDetailsPage());
        }

        private async void ViewBookList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookListPage());
        }
        private void ConnectionCheck_Clicked(object sender, EventArgs e)
        {
            GetDBFile();
        }

        private async void GetDBFile()
        {
            IFileService fileService = DependencyService.Get<IFileService>();
            string path = Isqlite.GetDirectoryPath();
            //fileService.CopyFileToDownloads(path, "library.db");
            fileService.CreateDBDirectory();
            fileService.CreateDBFile();
            fileService.CopyDatabase(path);

        }
    }
}