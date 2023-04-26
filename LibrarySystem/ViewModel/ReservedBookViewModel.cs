using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LibrarySystem.ViewModel
{
    public partial class ReservedBookViewModel: ObservableObject
    {
        IList<ReservedBookModel> source;
        DBconnection dbConnect = new DBconnection();
        public ObservableCollection<ReservedBookModel> reservedBooks { get; private set; }


        public ReservedBookViewModel()
        {
            CreateBookCollection();
        }

        // get book list
        void CreateBookCollection()
        {
            this.source = dbConnect.RetriveReservedBooks();

            reservedBooks = new ObservableCollection<ReservedBookModel>(source);
        }



        // log out the system
        [RelayCommand]
        async Task Logout()
        {
            await Shell.Current.GoToAsync("//Login");
        }


    }
}
