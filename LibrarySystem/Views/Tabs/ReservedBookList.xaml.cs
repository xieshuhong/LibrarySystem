using LibrarySystem.ViewModel;

namespace LibrarySystem.Views.Tabs;

public partial class ReservedBookList : ContentPage
{
	public ReservedBookList()
	{
		InitializeComponent();
        BindingContext = new ReservedBookViewModel();
    }
}