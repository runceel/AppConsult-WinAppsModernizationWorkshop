using Microsoft.UI.Xaml.Controls;

namespace Contoso.Expenses.WinddowsAppSdk.Converters
{
    public static class SymbolToIconElementConverter
    {
        public static IconElement Convert(Symbol symbol) => new SymbolIcon(symbol);
    }
}
