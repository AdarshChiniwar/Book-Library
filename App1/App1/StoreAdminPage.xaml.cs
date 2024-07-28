using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using Xamarin.Forms;
using MyBookLibrary.Contrcts;
using MyBookLibrary.Models;
using MyBookLibrary.ViewModels;

namespace App1
{
    public partial class StoreAdminPage : ContentPage
    {
        public StoreAdminPage(BookModel bookModel)
        {
            InitializeComponent();
            BindingContext = new StoreAdminPageViewModel(bookModel);
            
        }

     
       
    }
}