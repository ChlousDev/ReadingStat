using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.DataAccess
{
    public class ReadingStatisticsContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public ReadingStatisticsContext(string password)
        {
            if (this.Database.Connection is SQLiteConnection)
            {
                SQLiteConnection connection = (SQLiteConnection)this.Database.Connection;
                try //try to open the data base without password and change it so that the database is encrypted after initial use
                {
                    connection.Open();
                    connection.ChangePassword(password);
                }
                catch (Exception) //if the database is already encrypted trying to change the password without specifying the current password will throw an error.
                {
                    connection.Close(); //if the database is already encrypted the password has to be set before opening the database (else an exception is thrown)
                    connection.SetPassword(password);
                    connection.Open();
                }
            }
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Ignore(b => b.IsSelected);
            modelBuilder.Entity<Book>().Ignore(b => b.Language);
            modelBuilder.Entity<Book>().Ignore(b => b.Type);
        }
    }
}
