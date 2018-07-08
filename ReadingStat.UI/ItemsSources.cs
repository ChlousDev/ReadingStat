using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.UI
{
    public class ItemsSources
    {
        private static readonly Dictionary<ELanguage, string> languageItemsSource = new Dictionary<ELanguage, string>() {
            {ELanguage.English, "Englisch" },
             {ELanguage.German, "Deutsch" }
        };

        public Dictionary<ELanguage, string> LanguageItemsSource
        {
            get
            {
                return ItemsSources.languageItemsSource;
            }
        }

        private static readonly Dictionary<EType, string> typeItemsSource = new Dictionary<EType, string>() {
            {EType.Entertainment, "Unterhaltung" },
            {EType.Literature, "Literatur" }
        };

        public Dictionary<EType, string> TypeItemsSource
        {
            get
            {
                return ItemsSources.typeItemsSource;
            }
        }
    }
}
