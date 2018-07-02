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
    public class LanguageConverter : IValueConverter
    {
        private static readonly Dictionary<ELanguage, string> languageItemSource = new Dictionary<ELanguage, string>()
        {
            { ELanguage.English, "Englisch" },
            { ELanguage.German, "Deutsch" }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            if (value is ELanguage)
            {
                ELanguage language = (ELanguage)value;
                if (LanguageConverter.languageItemSource.ContainsKey(language))
                {
                    result = LanguageConverter.languageItemSource[language];
                }
                else
                {
                    result = language.ToString();
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ELanguage language = ELanguage.English;
            if (value != null)
            {
                string stringValue = value.ToString();
                if (LanguageConverter.languageItemSource.ContainsValue(stringValue))
                {
                    language = LanguageConverter.languageItemSource.FirstOrDefault(kvp => kvp.Value == stringValue).Key;
                }
                else
                {
                    Enum.TryParse(stringValue, out language);
                }
            }
            return language;
        }
    }
}
