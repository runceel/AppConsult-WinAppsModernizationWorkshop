using Contoso.Expenses.WinddowsAppSdk.Views;
using ContosoExpenses.Messages;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Linq;

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
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItem is MenuItem invokedItem) Navigate(invokedItem.Title, invokedItem.PageType);
    }

    private void Navigate(string title, Type pageType)
    {
        frame.Navigate(pageType, title);
    }

    private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
    {
        if (frame.CanGoBack) frame.GoBack();
    }

    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        frame.Navigated += Frame_Navigated;
        var initialPageMenu = MenuItems[0];
        navigationView.SelectedItem = initialPageMenu;
        Navigate(initialPageMenu.Title, initialPageMenu.PageType);
        WeakReferenceMessenger.Default.Register<SelectedEmployeeMessage>(this, (_, message) =>
        {
            Navigate("Expenses list", typeof(ExpensesListPage));
        });
    }

    private void Frame_Navigated(object sender, NavigationEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.Back)
        {
            var menuItem = MenuItems
                .FirstOrDefault(x => x.PageType == e.SourcePageType);
            if (menuItem is not null)
            {
                navigationView.Header = menuItem.Title;
                navigationView.SelectedItem = menuItem;
            }
        }
        else if (e.Parameter is string title)
        {
            navigationView.Header = title;
        }
    }

    private void Grid_Unloaded(object sender, RoutedEventArgs e)
    {
        frame.Navigated -= Frame_Navigated;
        WeakReferenceMessenger.Default.Unregister<SelectedEmployeeMessage>(this);
    }
}

record MenuItem(string Title, Symbol Icon, Type PageType);
