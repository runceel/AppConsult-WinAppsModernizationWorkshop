using ContosoExpenses.Messages;
using ContosoExpenses.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Windows.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Contoso.Expenses.WinddowsAppSdk.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ExpensesListPage : Page
{
    private ExpensesListViewModel ViewModel { get; } = App.ViewModelLocator.ExpensesListViewModel;
    public ExpensesListPage()
    {
        InitializeComponent();
        Loaded += (_, _) => ViewModel.IsActive = true;
        Unloaded += (_, _) => ViewModel.IsActive = false;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        App.Messenger.Register<AddNewExpenseMessage>(this, (_, _) =>
        {
            var window = new SubWindow(new AddNewExpenseView(), true);
            window.Activate();
        });

        App.Messenger.Register<SelectedExpenseMessage>(this, (_, message) =>
        {
            var page = new ExpenseDetailView();
            var window = new SubWindow(page);
            window.Activate();
        });
    }

    private void Page_Unloaded(object sender, RoutedEventArgs e)
    {
        App.Messenger.Unregister<AddNewExpenseMessage>(this);
        App.Messenger.Unregister<SelectedExpenseMessage>(this);
    }
}
