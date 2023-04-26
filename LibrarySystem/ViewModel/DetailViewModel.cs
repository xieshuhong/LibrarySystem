

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrarySystem.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibrarySystem.ViewModel
{

    public partial class DetailViewModel : ObservableObject, IQueryAttributable
    {
        public BookModel Book { get; private set; }

        // choose the start date from the date picker component
        public DateTime Startdate { get; set; } = DateTime.Now;

        // choose the end date from the date picker component
        public DateTime Endate { get; set; } = DateTime.Today;

        // for the user to input their booking name
        public string Username { get; set; } = "";

        // connect the mariaDB
        DBconnection dbConnect = new DBconnection();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Book = query["book"] as BookModel;
            OnPropertyChanged("Book");
        }

        // when you click the BOOK, this event will be triggered
        [RelayCommand]
        async Task reserveABook()
        {

            ReservedBookModel reservedBook = new ReservedBookModel{
                                                    Title = Book.Title,
                                                    Author = Book.Author,
                                                    Startdate = this.Startdate,
                                                    Endate = this.Endate,
                                                    Imagesource = Book.Imagesource,
                                                    Description = Book.Description,
                                                    Username = this.Username
                                                };
            await dbConnect.UpdateBooksStatus(reservedBook);
            await Shell.Current.GoToAsync("//BookListPage");
            Book.Status = "Unavailable";
            await Shell.Current.GoToAsync("//ReservedBookList");
            new ReservedBookViewModel();
        }
    }
}
