﻿using Microsoft.Win32;
using System;

namespace ContosoExpenses.Data.Services;

public class RegistryService
{
    public bool IsFirstTimeLaunch()
    {
        if (!OperatingSystem.IsWindows()) return false;

        var regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Contoso\ContosoExpenses", true);
        if (regKey == null)
        {
            regKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Contoso\ContosoExpenses", RegistryKeyPermissionCheck.ReadWriteSubTree);
            regKey.SetValue("FirstRun", "false");
            return true;
        }

        else
        {
            string isFirstRun = regKey.GetValue("FirstRun").ToString();
            if (isFirstRun == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
