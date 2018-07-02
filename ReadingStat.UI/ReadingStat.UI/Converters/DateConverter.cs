using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ReadingStat.UI.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                if (date > DateTime.MinValue)
                {
                    result = date.ToString("dd.MM.yyyy");
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime result = DateTime.MinValue;
            try
            {
                System.Convert.ToDateTime(value);
            }
            catch (Exception)
            { } //return min value already set as default
            return result;
        }
    }
}
