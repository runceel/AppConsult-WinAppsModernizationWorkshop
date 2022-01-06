using ContosoExpenses.Messages;
using ContosoExpenses.ViewModels;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Contoso.Expenses.WinddowsAppSdk.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExpensesListPage : Page
    {
        private ExpensesListViewModel _viewModel;
        private ExpensesListViewModel ViewModel => _viewModel ??= App.ViewModelLocator.ExpensesListViewModel;
        public ExpensesListPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Register<AddNewExpenseMessage>(this, async (_, _) =>
            {
                var dialog = new ContentDialog
                {
                    XamlRoot = XamlRoot,
                    CloseButtonText = "Close",
                };
                await dialog.ShowAsync();
            });
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Unregister<AddNewExpenseMessage>(this);
        }
    }
}
