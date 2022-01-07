using Contoso.Expenses.WinddowsAppSdk.Views;
using ContosoExpenses.Messages;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Contoso.Expenses.WinddowsAppSdk;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private MenuItem[] MenuItems { get; } = new MenuItem[]
    {
            new("Employee list", Symbol.AllApps, typeof(MainPage)),
            new("About", Symbol.Contact, typeof(AboutPage)),
    };
    public MainWindow()
    {
        InitializeComponent();
        foreach (var item in MenuItems)
        {
            navigationView.MenuItems.Add(new NavigationViewItem
            {
                Content = item.Title,
                Icon = new SymbolIcon(item.Icon),
                Tag = item,
            });
        }
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItemContainer.Tag is MenuItem invokedItem) Navigate(invokedItem.Title, invokedItem.PageType);
    }

    private void Navigate(string title, Type pageType)
    {
        navigationView.Header = title;
        frame.Navigate(pageType);
    }

    private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
    {
        if (frame.CanGoBack) frame.GoBack();
    }

    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        Navigate(MenuItems[0].Title, MenuItems[0].PageType);
        WeakReferenceMessenger.Default.Register<SelectedEmployeeMessage>(this, (_, message) =>
        {
            Navigate("Expenses list", typeof(ExpensesListPage));
        });
    }
}

record MenuItem(string Title, Symbol Icon, Type PageType);
