using LibrarySystem.ViewModel;
using LibrarySystem.Views.Registration;

namespace LibrarySystem.Views.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage(MainViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}