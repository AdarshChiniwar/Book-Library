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
using MyBookLibrary.ViewModels;

namespace App1
{
    public partial class BookDetailsPage : ContentPage
    {
       
        public BookDetailsPage()
        {
            InitializeComponent();
            BindingContext = new BookDetailPageViewModel();
        }

    }
}
