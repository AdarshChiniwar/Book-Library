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
            ImageCollection.Add(new ImageModel { CauroselImage = "https://images.ctfassets.net/qpn1gztbusu2/7bsPTtX0rMiz3Z4T7E4syT/d8f870a5f088ba968cfed13f3cc7132d/quote-1-2.png" });
            ImageCollection.Add(new ImageModel { CauroselImage = "https://basmo.app/wp-content/uploads/2021/12/quotes-about-reading-books-1024x690.webp" });
            ImageCollection.Add(new ImageModel { CauroselImage = "https://images.squarespace-cdn.com/content/v1/58d1b3ff1b631bb1893d108d/83cd724a-3059-4895-b7b4-657ebc631533/quotes-about-children3.png" });
            ImageCollection.Add(new ImageModel { CauroselImage = "https://i0.wp.com/malissagreenwood.com/wp-content/uploads/2022/01/You-Are-a-Badass-Review-best-quotes-quotationremarks.png?resize=1080%2C400&ssl=1" });
            ImageCollection.Add(new ImageModel { CauroselImage = "https://st3.depositphotos.com/8865038/37657/i/450/depositphotos_376572560-stock-photo-yellow-sticky-note-on-wooden.jpg" });

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