# Contoso Expenses on .NET 6

This repository is a lab for migrating to Windows App SDK on .NET 6 from WPF on .NET Core 3.1. The original app is Contoso Expenses sample app for migration lab to WPF on .NET Core 3.1 from .NET Framework.

https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/

## Migration steps

1. Migrate to .NET 6 from .NET Core 3.1
2. Migrate to Microsoft.Toolkit.Mvvm from Mvvm Light Toolkit
3. Migrate to Microsoft.Extensions.DependencyInjection from Unity
4. Separe project between Views and ViewModels
5. Add a View project for Windows App SDK
6. Implement the view project

## The result

WPF version

!()[assets/contoso_expenses_wpf.gif]

Windows App SDK version

!()[assets/contoso_expenses_winappsdk.gif]
