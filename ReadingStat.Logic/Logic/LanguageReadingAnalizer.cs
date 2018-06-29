using ReadingStat.Logic.DataAccess;
using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.Logic
{
    public class LanguageReadingAnalizer: ReadingAnalizer
    {
        private ELanguage language;

        public LanguageReadingAnalizer(ReadintStatDataAccess dataAccess, ELanguage language): base(dataAccess)
        {
            this.language = language;
        }

        protected override List<Book> LoadBooks()
        {
            return this.dataAccess.GetFinishedBooks(this.language);
        }
    }
}
