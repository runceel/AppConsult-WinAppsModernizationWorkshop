using ContosoExpenses.Data.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ContosoExpenses.ViewModels;

public partial class ExpensesDetailViewModel : ObservableObject
{
    [ObservableProperty]
    private string _expenseType;

    [ObservableProperty]
    private string _description;

    [ObservableProperty]
    private string _location;

    [ObservableProperty]
    private double _amount;

    public ExpensesDetailViewModel(IDatabaseService databaseService, IStorageService storageService)
    {
        var expense = databaseService.GetExpense(storageService.SelectedExpense);

        ExpenseType = expense.Type;
        Description = expense.Description;
        Location = expense.Address;
        Amount = expense.Cost;
    }
}
