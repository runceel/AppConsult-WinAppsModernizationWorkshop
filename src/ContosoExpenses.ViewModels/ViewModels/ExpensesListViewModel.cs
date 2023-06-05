using ContosoExpenses.Data.Models;
using ContosoExpenses.Data.Services;
using ContosoExpenses.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Windows.Input;

namespace ContosoExpenses.ViewModels;

public partial class ExpensesListViewModel : ObservableRecipient, IRecipient<UpdateExpensesListMessage>
{
    private readonly IDatabaseService _databaseService;
    private readonly IStorageService _storageService;

    [ObservableProperty]
    private Employee _selectedEmployee;

    [ObservableProperty]
    private string _fullName;

    [ObservableProperty]
    private List<Expense> _expenses;

    [ObservableProperty]
    private Expense _selectedExpense;

    partial void OnSelectedExpenseChanging(Expense value)
    {
        if (value is null) return;

        _storageService.SelectedExpense = value.ExpenseId;
        Messenger.Send(new SelectedExpenseMessage());
    }

    [RelayCommand]
    private void AddNewExpense()
    {
        Messenger.Send(new AddNewExpenseMessage());
    }

    public void Receive(UpdateExpensesListMessage _)
    {
        Expenses = _databaseService.GetExpenses(_storageService.SelectedEmployeeId);
    }

    public ExpensesListViewModel(IDatabaseService databaseService, IStorageService storageService, IMessenger messenger)
        : base(messenger)
    {
        SelectedEmployee = databaseService.GetEmployee(storageService.SelectedEmployeeId);
        Expenses = databaseService.GetExpenses(storageService.SelectedEmployeeId);

        FullName = $"{SelectedEmployee.FirstName} {SelectedEmployee.LastName}";

        _databaseService = databaseService;
        _storageService = storageService;
    }
}
