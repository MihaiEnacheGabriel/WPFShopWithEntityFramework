using System;
using System.Globalization;
using System.Windows.Data;

namespace MVPTema3.Converters
{
    public class ExpiryDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime expiryDate)
            {
                return expiryDate != DateTime.MinValue ? expiryDate.ToString("yyyy-MM-dd") : "Not in stock";
            }

            return "Not in stock";
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
