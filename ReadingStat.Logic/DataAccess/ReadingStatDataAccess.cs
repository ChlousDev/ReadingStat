
using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.DataAccess
{
    public class ReadingStatDataAccess
    {
        ReadingStatisticsContext dbContext;
        public static String Password { get; set; }

        public ReadingStatDataAccess()
        {
            dbContext = new ReadingStatisticsContext(ReadingStatDataAccess.Password);
        }

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

        public List<Book> GetFinishedBooks(EType type)
        {
            string typeString = type.ToString();
            return this.GetFinishedBooksBase().Where(l => l.TypeString == typeString).ToList();
        }

        private IEnumerable<Book> GetFinishedBooksBase()
        {
            return this.GetBooksBase().Where(b => b.StartDate != DateTime.MinValue && b.EndDate != DateTime.MinValue);
        }

        private IEnumerable<Book> GetBooksBase()
        {
            return this.dbContext.Books.OrderByDescending(b => b.StartDate);
        }

        public void RemoveBook(Book book)
        {
            this.dbContext.Books.Attach(book);
            this.dbContext.Books.Remove(book);
            this.dbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            this.dbContext.Books.Attach(book);
            this.dbContext.Entry(book).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void AddBook(Book book)
        {
            this.dbContext.Books.Add(book);
            this.dbContext.SaveChanges();
        }

        public void Export(string destinationPath)
        {
            string destinationConnectionString = $"Data Source=|DataDirectory|{destinationPath}";
            this.dbContext.Export(destinationConnectionString);
        }
    }
}
