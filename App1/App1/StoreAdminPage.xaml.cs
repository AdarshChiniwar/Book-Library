using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using Xamarin.Forms;
using MyBookLibrary.Contrcts;

namespace App1
{
    public partial class StoreAdminPage : ContentPage
    {
        //SqlConnection sqlConnection;
        SQLite.SQLiteConnection sqliteConnection;
        public StoreAdminPage()
        {
            InitializeComponent();
            sqliteConnection = DependencyService.Get<Isqlite>().GetConnection();
            //sqlConnection = new SqlConnection("Data Source=192.168.37.239;Initial Catalog=mydb;User ID=Deepti;Password=Deepti;Encrypt=False");
        }

        private async void ConnectionCheck_Clicked(object sender, EventArgs e)
        {
            try
            {
                //sqlConnection.Open();
                await DisplayAlert("Congratulations !!", "Your Mobile Application Connected with SQL database !!", "OK");
                //sqlConnection.Close();
            }
            catch (SqlException sqlEx)
            {
                await DisplayAlert("Error", sqlEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                throw;
            }
        }

       

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                //sqlConnection.Open();
                //int idToDelete = Convert.ToInt32(Idtext.Text);
                //using (SqlCommand command = new SqlCommand($"DELETE FROM dbo.Book WHERE Id={idToDelete}", sqlConnection))
                //{
                //    command.ExecuteNonQuery();
                //}
                //sqlConnection.Close();
                await DisplayAlert("Info", "Congratulations !!! You deleted data", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                throw;
            }
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                //sqlConnection.Open();

                //int IdToBeUpdated = Convert.ToInt32(Idtext.Text);
                //string TitleToBeUpdated = TitleText.Text;
                //string AuthorToBeUpdated = AuthorText.Text;
                //int PriceToBeUpdated = Convert.ToInt32(PriceText.Text);

                //string updateQuery = $"UPDATE dbo.Book SET Title='{TitleToBeUpdated}', Author='{AuthorToBeUpdated}', Price='{PriceToBeUpdated}' WHERE Id='{IdToBeUpdated}'";
                //using (SqlCommand command = new SqlCommand(updateQuery, sqlConnection))
                //{
                //    command.ExecuteNonQuery();
                //}
                //sqlConnection.Close();
                await DisplayAlert("Info", "Congratulations !!! Your data has been updated", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                throw;
            }
        }

        private async void ViewButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                //sqlConnection.Open();
                //string queryString = "SELECT * FROM dbo.Book";
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

                await Navigation.PushAsync(new BookListPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                throw;
            }
        }

       
    }
}