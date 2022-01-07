using Microsoft.UI.Xaml.Data;
using System;

namespace Contoso.Expenses.WinddowsAppSdk.Converters
{
    public class CostToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                double cost = (double)value;
                double height = cost * 400 / 1000;
                return height;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}
