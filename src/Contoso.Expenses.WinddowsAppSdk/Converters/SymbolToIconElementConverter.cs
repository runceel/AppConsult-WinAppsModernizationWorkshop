using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Expenses.WinddowsAppSdk.Converters
{
    public static class SymbolToIconElementConverter
    {
        public static IconElement Convert(Symbol symbol) => new SymbolIcon(symbol);
    }
}
