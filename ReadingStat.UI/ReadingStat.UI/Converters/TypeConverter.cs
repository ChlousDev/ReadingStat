using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ReadingStat.UI.Converters
{
    public class TypeConverter : IValueConverter
    {
        private static readonly Dictionary<EType, string> typeItemSource = new Dictionary<EType, string>()
        {
            { EType.Entertainment, "Unterhaltung" },
            { EType.Literature, "Literatur" }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            if (value is EType)
            {
                EType type = (EType)value;
                if (TypeConverter.typeItemSource.ContainsKey(type))
                {
                    result = TypeConverter.typeItemSource[type];
                }
                else
                {
                    result = type.ToString();
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EType type = EType.Entertainment;
            if (value != null)
            {
                string stringValue = value.ToString();
                if (TypeConverter.typeItemSource.ContainsValue(stringValue))
                {
                    type = TypeConverter.typeItemSource.FirstOrDefault(kvp => kvp.Value == stringValue).Key;
                }
                else
                {
                    Enum.TryParse(stringValue, out type);
                }
            }
            return type;
        }
    }
}
