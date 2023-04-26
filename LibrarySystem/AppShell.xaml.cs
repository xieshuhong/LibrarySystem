using LibrarySystem.Views;
using LibrarySystem.Views.Login;

namespace LibrarySystem;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
    }
}
