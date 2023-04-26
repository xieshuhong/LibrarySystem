using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrarySystem.Models;
using LibrarySystem.Views.Registration;
using System.Security;

namespace LibrarySystem.ViewModel
{
    public partial class MainViewModel :ObservableObject
    {
        // connect to the maria DB
        DBconnection dbConnect = new DBconnection();

        // using OnPropertyChanged so that I can clear the input content after log out
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        // using OnPropertyChanged so that I can clear the input content after log out
        private int? _password;
        public int? Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public MainViewModel() {
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
        }



        // go to the registration page
        [RelayCommand]
        public async Task Tap()
        {
            await Shell.Current.GoToAsync("RegistrationPage");
        }


        // go to the book list page
        [RelayCommand]
        public async void GotoBook()
        {
            bool isLogined  =dbConnect.Select(Username, Password);
            if (isLogined)
            {
                Shell.Current.DisplayAlert("", "You have successfully logined in", "Cancel");
                await Shell.Current.GoToAsync("//Main");
                Username = "";
                Password = null;
                
            } else
            {
                Shell.Current.DisplayAlert("", "Please check your username and password!", "Cancel");
            }
        }



    }

}
