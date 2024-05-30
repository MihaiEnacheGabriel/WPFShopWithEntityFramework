using System;
using System.Globalization;
using System.Windows.Data;

namespace MVPTema3.Converters
{
    public class SellPriceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return null;

            if (values[0] is decimal purchasePrice && values[1] is decimal markup)
            {
                return purchasePrice * (1 + (markup / 100));
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
