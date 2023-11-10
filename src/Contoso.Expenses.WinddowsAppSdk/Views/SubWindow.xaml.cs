using ContosoExpenses.Messages;
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
using CommunityToolkit.Mvvm.Messaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Contoso.Expenses.WinddowsAppSdk.Views;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class SubWindow : Window
{
    public SubWindow(Page page, bool handleCloseWindowMessage = false)
    {
        InitializeComponent();
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);

        SystemBackdrop = new MicaBackdrop();
        _frame.Content = page;

        if (handleCloseWindowMessage)
        {
            _frame.Loaded += Frame_Loaded;
            Closed += SubWindow_Closed;
        }
    }

    private void Frame_Loaded(object sender, RoutedEventArgs e)
    {
        App.Messenger.Register<CloseWindowMessage>(this, (s, message) =>
        {
            if (((Page)_frame.Content).DataContext == message.Sender)
            {
                Close();
            }
        });
    }

    private void SubWindow_Closed(object sender, WindowEventArgs args)
    {
        App.Messenger.Unregister<CloseWindowMessage>(this);
    }

}
