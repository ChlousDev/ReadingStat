using ReadingStat.Logic.DataAccess;
using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.Logic
{
    public class TypeReadingAnalizer : ReadingAnalizer
    {
        private EType type;

        public TypeReadingAnalizer(ReadingStatDataAccess dataAccess, EType type) : base(dataAccess)
        {
            this.type = type;
        }

        protected override List<Book> LoadBooks()
        {
            return this.dataAccess.GetFinishedBooks(this.type);
        }
    }
}
