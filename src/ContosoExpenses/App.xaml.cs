using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Windows;

namespace ContosoExpenses;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static new App Current => (App)Application.Current;
    public IMessenger Messenger => (Resources["ViewModelLocator"] as ViewModelLocator)?.Messenger ?? throw new InvalidOperationException();
}
