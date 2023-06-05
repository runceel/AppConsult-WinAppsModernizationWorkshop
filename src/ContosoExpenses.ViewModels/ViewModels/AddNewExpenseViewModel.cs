using ContosoExpenses.Data.Models;
using ContosoExpenses.Data.Services;
using ContosoExpenses.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;

namespace ContosoExpenses.ViewModels;

public partial class AddNewExpenseViewModel : ObservableRecipient
{
    private readonly IDatabaseService _databaseService;
    private readonly IStorageService _storageService;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveExpenseCommand))]
    private string _address;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveExpenseCommand))]
    private string _city;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveExpenseCommand))]
    private double _cost;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveExpenseCommand))]
    private string _description;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveExpenseCommand))]
    private string _expenseType;

    [ObservableProperty]
    private DateTimeOffset _date;


    public AddNewExpenseViewModel(IDatabaseService databaseService, IStorageService storageService, IMessenger messenger)
        : base(messenger)
    {
        _databaseService = databaseService;
        _storageService = storageService;

        Date = DateTime.Today;
    }

    private bool IsFormFilled => 
        !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Description) && 
        !string.IsNullOrEmpty(ExpenseType) && Cost != 0;

    [RelayCommand(CanExecute = nameof(IsFormFilled))]
    private void SaveExpense()
    {
        Expense expense = new()
        {
            Address = Address,
            City = City,
            Cost = Cost,
            Date = Date.DateTime,
            Description = Description,
            EmployeeId = _storageService.SelectedEmployeeId,
            Type = ExpenseType
        };

        _databaseService.SaveExpense(expense);
        Messenger.Send(new UpdateExpensesListMessage());
        Messenger.Send(new CloseWindowMessage());
    }
}
