using ReadingStat.Logic.DataAccess;
using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.Logic
{
    public class ReadingAnalizer
    {
        protected ReadingStatDataAccess dataAccess;

        public ReadingAnalizer(ReadingStatDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        protected virtual List<Book> LoadBooks()
        {
            return this.dataAccess.GetFinishedBooks();
        }

        public ReadingStatistics Analize()
        {
            List<Book> books = this.LoadBooks();
            ReadingStatistics statitics = new ReadingStatistics()
            {
                NumberOfBooks = books.Count(),
                TotalPages = books.Sum(b => b.NumberOfPages),
                TotalReadingDays = books.Sum(b => b.ReadingDays.HasValue ? b.ReadingDays.Value : 0),
            };
            return statitics;
        }
    }
}
