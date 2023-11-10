// ******************************************************************

// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.

// ******************************************************************

using System.Windows;
using ContosoExpenses.Messages;
using CommunityToolkit.Mvvm.Messaging;
using ContosoExpenses.ViewModels;

namespace ContosoExpenses.Views;

/// <summary>
/// Interaction logic for ExpensesList.xaml
/// </summary>
public partial class ExpensesList : Window
{
    private ExpensesListViewModel ViewModel => (ExpensesListViewModel)DataContext;

    public ExpensesList()
    {
        InitializeComponent();
        App.Current.Messenger.Register<AddNewExpenseMessage>(this, (_, message) =>
        {
            AddNewExpense addNewExpense = new();
            addNewExpense.Show();
        });

        App.Current.Messenger.Register<SelectedExpenseMessage>(this, (_, message) =>
        {
            ExpenseDetail detail = new();
            detail.Show();
        });
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        ViewModel.IsActive = true;
    }

    private void Window_Closed(object sender, System.EventArgs e)
    {
        ViewModel.IsActive = false;
    }
}
