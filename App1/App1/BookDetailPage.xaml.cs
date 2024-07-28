using App1.Services;
using App1.Views;
using System;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1;
using SQLite;
using MyBookLibrary.Contrcts;
using MyBookLibrary.Models;

namespace App1
{
    public partial class BookDetailsPage : ContentPage
    {
        //SqlConnection sqlConnection;
        Isqlite Isqlite;
        SQLite.SQLiteConnection sqliteConnection;
        public BookDetailsPage()
        {
            InitializeComponent();
            Isqlite = DependencyService.Get<Isqlite>();
            sqliteConnection = Isqlite.GetConnection();
            //sqlConnection = new SqlConnection("Data Source=192.168.37.239;Initial Catalog=mydb;User ID=Deepti;Password=Deepti;Encrypt=False");
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                BookModel bookModel = new BookModel()
                {
                   
                    Title = TitleText.Text,
                    Author = AuthorText.Text,
                    Price = PriceText.Text
                };
                int result = sqliteConnection.Insert(bookModel);
                if (result == 1)
                {
                    await DisplayAlert("Info", "Congratulations , Data inserted Successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Registration Failled!!!", "Please try again", "ERROR");
                }
                //sqlConnection.Open();

                //using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Book VALUES (@Id, @Title, @Author, @Price)", sqlConnection))
                //{
                //    command.Parameters.Add(new SqlParameter("@Id", Idtext.Text));
                //    command.Parameters.Add(new SqlParameter("@Title", TitleText.Text));
                //    command.Parameters.Add(new SqlParameter("@Author", AuthorText.Text));
                //    command.Parameters.Add(new SqlParameter("@Price", PriceText.Text));
                //    command.ExecuteNonQuery();
                //}

                //sqlConnection.Close();
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                throw;
            }
        }

    }
}
