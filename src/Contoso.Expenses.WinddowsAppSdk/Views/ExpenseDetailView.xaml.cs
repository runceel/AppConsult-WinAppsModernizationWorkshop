using ContosoExpenses.ViewModels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Contoso.Expenses.WinddowsAppSdk.Views;

public sealed partial class ExpenseDetailView : UserControl
{
    private ExpensesDetailViewModel ViewModel { get; } = App.ViewModelLocator.ExpensesDetailViewModel;
    public ExpenseDetailView()
    {
        this.InitializeComponent();
    }
}
