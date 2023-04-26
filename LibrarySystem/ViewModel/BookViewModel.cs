using CommunityToolkit.Mvvm.Input;
using LibrarySystem.Models;
using LibrarySystem.Views.Login;
using LibrarySystem.Views.Tabs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LibrarySystem.ViewModel
{
    public partial class BookViewModel
    {
        IList<BookModel> source;

        // create a new dbconnect instance
        DBconnection dbConnect = new DBconnection();

        public ObservableCollection<BookModel> Books { get; private set; }



        public BookViewModel()
        {
            // get the listed book
            CreateBookCollection();

        }

        // get the books for the db
        void CreateBookCollection()
        {
            this.source = dbConnect.RetriveBooks();

            Books = new ObservableCollection<BookModel>(source);
        }



        [RelayCommand]
        async Task Logout()
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
