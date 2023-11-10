using ContosoExpenses.Messages;
using ContosoExpenses.ViewModels;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.Messaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Contoso.Expenses.WinddowsAppSdk.Views;

public sealed partial class AddNewExpenseView : Page
{
    public AddNewExpenseViewModel ViewModel { get; } = App.ViewModelLocator.AddNewExpenseViewModel;
    public AddNewExpenseView()
    {
        InitializeComponent();
    }
}
