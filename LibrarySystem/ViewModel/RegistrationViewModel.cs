using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using LibrarySystem.Models;

namespace LibrarySystem.ViewModel
{
    public partial class RegistrationViewModel
    {
        // connect to the maria DB
        DBconnection dbConnect = new DBconnection();

        // new user name
        public string name { get; set; }
        // new password
        public int? password { get; set; }
        // new email
        public string email { get; set; }
        public RegistrationViewModel()
        {
        }

        [RelayCommand]
        public void RegisterUser()
        {

            if (string.IsNullOrEmpty(name) || this.password == 0 || string.IsNullOrEmpty(email))
            {
                Shell.Current.DisplayAlert("", "Please input your username, password or email!", "Cancel");
                return;
            }
            User user = new User
                        {
                            name = name,
                            password = (int)this.password,
                            email = email,
                         };
            if (!String.IsNullOrEmpty(name) && password != 0 && !String.IsNullOrEmpty(email))
            {
                dbConnect.InsertAUser(user);
                Shell.Current.DisplayAlert("", "You have successfully created a new account", "Cancel");
                Shell.Current.GoToAsync("//Login");
            } else
            {
                Shell.Current.DisplayAlert("", "Please check your username, password or email!", "Cancel");
            }
        }
    }
}
