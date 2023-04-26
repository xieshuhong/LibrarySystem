using LibrarySystem.ViewModel;

namespace LibrarySystem.Views.Registration;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
        BindingContext = new RegistrationViewModel();
    }


}