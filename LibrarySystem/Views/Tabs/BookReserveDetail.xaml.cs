using LibrarySystem.ViewModel;

namespace LibrarySystem.Views.Tabs;

public partial class BookReserveDetail : ContentPage
{
    public BookReserveDetail()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ReservedBookList), typeof(ReservedBookList));
        BindingContext = new DetailViewModel();
	}
}