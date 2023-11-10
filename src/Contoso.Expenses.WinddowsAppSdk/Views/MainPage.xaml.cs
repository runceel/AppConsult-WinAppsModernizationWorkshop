using ContosoExpenses.Data.Models;
using ContosoExpenses.Messages;
using ContosoExpenses.ViewModels;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.Messaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Contoso.Expenses.WinddowsAppSdk.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
    public MainWindowViewModel ViewModel { get; } = App.ViewModelLocator.MainWindowViewModel;
    public MainPage()
    {
        InitializeComponent();
        App.Messenger.Register<SelectedEmployeeMessage>(this, (_, message) =>
        {
            var window = new SubWindow(new ExpensesListPage());
            window.Activate();
        });
    }
}
