using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.DataAccess
{
    public class ReadingStatDataAccess
    {
        private static readonly List<Book> books = new List<Book>() {
            new Book()
            {
                Title="Moby Dick Or: The Wahle",
                Author="Herman Melville",
                 StartDate = new DateTime(2018,6,1),
                 EndDate = new DateTime(2018,8,1),
                  Language = ELanguage.English,
                   NumberOfPages = 592,
            },
            new Book()
            {
                Title="Elfenlicht",
                Author="Bernhard Hennen",
                 StartDate = new DateTime(2018,5,1),
                 EndDate = new DateTime(2018,6,1),
                  Language = ELanguage.German,
                   NumberOfPages = 976,
            },
            new Book()
            {
                Title="Honors Mission",
                Author="David Weber",
                 StartDate = new DateTime(2018,8,1),
                // EndDate = new DateTime(2018,8,1),
                  Language = ELanguage.German,
                   NumberOfPages = 470,
            },
            new Book()
            {
                Title="Der letzte Befehl",
                Author="Honor Harrington",
                 StartDate = new DateTime(2018,4,1),
                 EndDate = new DateTime(2018,5,1),
                  Language = ELanguage.German,
                   NumberOfPages = 389,
            },
            new Book()
            {
                Title="Elfenkönigin",
                Author="Bernhard Hennen",
                 //StartDate = new DateTime(2018,6,1),
                 //EndDate = new DateTime(2018,8,1),
                  Language = ELanguage.German,
                   NumberOfPages = 950,
            },
            new Book()
            {
                Title="I, Robot",
                Author="Isaac Asimov",
                 StartDate = new DateTime(2018,3,1),
                 EndDate = new DateTime(2018,4,1),
                  Language = ELanguage.English,
                   NumberOfPages = 241,
            },
        };

        public List<Book> GetBooks(int page, int pageSize)
        {
            return this.GetBooksBase().Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Book> GetFinishedBooks()
        {
            return this.GetFinishedBooksBase().ToList();
        }

        public List<Book> GetFinishedBooks(ELanguage language)
        {
            string languageString = language.ToString();
            return this.GetFinishedBooksBase().Where(l => l.LanguageString == languageString).ToList();
        }

        private IEnumerable<Book> GetFinishedBooksBase()
        {
            return this.GetBooksBase().Where(b => b.StartDate != DateTime.MinValue && b.EndDate != DateTime.MinValue);
        }

        private IEnumerable<Book> GetBooksBase()
        {
            List<Book> books = new List<Book>();
            books.AddRange(ReadingStatDataAccess.books);
            //books.AddRange(ReadingStatDataAccess.books);
            //books.AddRange(ReadingStatDataAccess.books);
            //books.AddRange(ReadingStatDataAccess.books);
            //books.AddRange(ReadingStatDataAccess.books);

            return books.OrderByDescending(b => b.StartDate);
        }
    }
}
