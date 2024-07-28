using App1.Services;
using App1.Views;
using MyBookLibrary.Contrcts;
using MyBookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class BookListPage : ContentPage
    {
        //SqlConnection sqlConnection;
        SQLite.SQLiteConnection sqliteConnection;
     
        public BookListPage()
        {
            InitializeComponent();
            sqliteConnection = DependencyService.Get<Isqlite>().GetConnection();
            //sqlConnection = new SqlConnection("Data Source=192.168.37.239;Initial Catalog=mydb;User ID=Deepti;Password=Deepti;Encrypt=False");
            LoadBookList();
        }

        private async void LoadBookList()
        {
            try
            {
                var details = (from x in sqliteConnection.Table<BookModel>() select x).ToList();
                BookListView.ItemsSource = details;
                //sqlConnection.Open();
                //string queryString = "select * from dbo.Book";
                //SqlCommand command = new SqlCommand(queryString, sqlConnection);
                //SqlDataReader sqlDataReader = command.ExecuteReader();

                //List<MyTableList> list = new List<MyTableList>();
                //while (sqlDataReader.Read())
                //{
                //    list.Add(new MyTableList
                //    {
                //        Id = Convert.ToInt32(sqlDataReader["ID"]),
                //        Title = sqlDataReader["Title"].ToString(),
                //        Author = sqlDataReader["Author"].ToString(),
                //        Price = Convert.ToInt32(sqlDataReader["Price"])
                //    });
                //}
                //sqlDataReader.Close();
                //sqlConnection.Close();

                //BookListView.ItemsSource = list;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
    public class MyTableList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}
