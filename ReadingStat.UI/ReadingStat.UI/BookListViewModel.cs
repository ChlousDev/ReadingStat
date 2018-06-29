using Mvvm.Commands;
using ReadingStat.Logic.DataAccess;
using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.UI
{
    public class BookListViewModel : INotifyPropertyChanged
    {
        private const int PageSize = 25;
        private int currentPage;

        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get
            {
                return this.books;
            }
        }

        public DelegateCommand NextPageCommand { get; private set; }
        public DelegateCommand PreviousPageCommand { get; private set; }

        public BookListViewModel()
        {
            this.currentPage = 1;
            this.books = new ObservableCollection<Book>();

            this.NextPageCommand = new DelegateCommand(() => this.Load(this.currentPage + 1), ()=>this.Books.Count==BookListViewModel.PageSize);
            this.PreviousPageCommand = new DelegateCommand(() => this.Load(this.currentPage - 1), () => this.currentPage > 1);

            this.Load(this.currentPage);
        }      

        private void Load(int page)
        {
            this.Books.Clear();
            ReadingStatDataAccess dataAccess = new ReadingStatDataAccess();
            List<Book> books = dataAccess.GetBooks(page, BookListViewModel.PageSize);
            foreach(Book book in books)
            {
                this.Books.Add(book);
            }
            this.currentPage = page;

            this.NextPageCommand.RaiseCanExecuteChanged();
            this.PreviousPageCommand.RaiseCanExecuteChanged();
        }

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Property Changed
    }
}
