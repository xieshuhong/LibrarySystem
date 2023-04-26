using LibrarySystem.ViewModel;
using LibrarySystem.Views.Tabs;
using LibrarySystem.Views.Login;
using LibrarySystem.Views.Registration;
using CommunityToolkit.Maui;

namespace LibrarySystem;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<RegistrationPage>();
        builder.Services.AddTransient<RegistrationPage>();
        builder.Services.AddTransient<BookListPage>();
        builder.Services.AddTransient<BookListPage>();
        builder.Services.AddTransient<BookReserveDetail>();
        builder.Services.AddTransient<BookReserveDetail>();
        builder.Services.AddTransient<ReservedBookList>();
        builder.Services.AddTransient<ReservedBookList>();
        return builder.Build();
    }
}
