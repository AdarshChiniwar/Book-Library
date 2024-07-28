
using MyBookLibrary.ViewModels;
using Xamarin.Forms;


namespace App1
{
    public partial class BookListPage : ContentPage
    {
        public BookListPage()
        {
            InitializeComponent();
            BindingContext = new BookListPageViewModel();
        }
    }
}
