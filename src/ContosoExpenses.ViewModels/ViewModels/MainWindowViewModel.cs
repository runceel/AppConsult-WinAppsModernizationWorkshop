using ContosoExpenses.Data.Models;
using ContosoExpenses.Data.Services;
using ContosoExpenses.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;

namespace ContosoExpenses.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient
{
    private readonly IStorageService _storageService;

    [ObservableProperty]
    private List<Employee> _employees;

    [ObservableProperty]
    private Employee _selectedEmployee;

    partial void OnSelectedEmployeeChanging(Employee value)
    {
        _storageService.SelectedEmployeeId = value.EmployeeId;
        Messenger.Send(new SelectedEmployeeMessage());
    }

    public MainWindowViewModel(IDatabaseService databaseService, IStorageService storageService, IMessenger messenger)
        : base(messenger)
    {
        databaseService.InitializeDatabase();
        Employees = databaseService.GetEmployees();
        _storageService = storageService;
    }
}
