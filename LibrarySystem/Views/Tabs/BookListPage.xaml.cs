using LibrarySystem.Models;
using LibrarySystem.ViewModel;
using System.Diagnostics;
using System.Text.Json;

namespace LibrarySystem.Views.Tabs;

public partial class BookListPage : ContentPage
{
	public BookListPage()
	{
		InitializeComponent();
        // register a router so can you go to this page
        Routing.RegisterRoute(nameof(BookReserveDetail), typeof(BookReserveDetail));
        BindingContext = new BookViewModel();
    }


    // when you click a specific book, this event will be triggered.
    async void onItemClicked(object sender, SelectedItemChangedEventArgs args)
    {
        BookModel item = args.SelectedItem as BookModel;
        var navigationParameters = new Dictionary<string, object>
            {
                { "book", item }
            };
        await Shell.Current.GoToAsync($"BookReserveDetail", navigationParameters);
    }

};