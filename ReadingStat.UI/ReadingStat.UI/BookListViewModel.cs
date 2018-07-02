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
        public DelegateCommand RemoveBookCommand { get; private set; }
        public DelegateCommand AddBookCommand { get; private set; }
        public DelegateCommand EditBookCommand { get; private set; }

        public BookListViewModel()
        {
            this.currentPage = 1;
            this.books = new ObservableCollection<Book>();

            this.NextPageCommand = new DelegateCommand(() => this.Load(this.currentPage + 1), () => this.Books.Count == BookListViewModel.PageSize);
            this.PreviousPageCommand = new DelegateCommand(() => this.Load(this.currentPage - 1), () => this.currentPage > 1);

            this.AddBookCommand = new DelegateCommand(() => this.AddBook());
            this.EditBookCommand = new DelegateCommand(() => this.EditBook());
            this.RemoveBookCommand = new DelegateCommand(() => this.RemoveBook());

            this.Load(this.currentPage);
        }

        private void Load(int page)
        {
            this.Books.Clear();
            ReadingStatDataAccess dataAccess = new ReadingStatDataAccess();
            List<Book> books = dataAccess.GetBooks(page, BookListViewModel.PageSize);
            foreach (Book book in books)
            {
                this.Books.Add(book);
            }
            this.currentPage = page;

            this.NextPageCommand.RaiseCanExecuteChanged();
            this.PreviousPageCommand.RaiseCanExecuteChanged();
        }

        private void AddBook()
        {
            Book book = new Book() { StartDate = DateTime.Today, EndDate = DateTime.Today, Language = ELanguage.German, Type = EType.Entertainment };
            BookDetailWindow newBookWindow = new BookDetailWindow();
            newBookWindow.DataContext = book;
            bool? save = newBookWindow.ShowDialog();
            if (save == true)
            {
                ReadingStatDataAccess dataAccess = new ReadingStatDataAccess();
                dataAccess.AddBook(book);
                this.Load(this.currentPage);
            }
        }

        private void EditBook()
        {
            Book book = this.Books.FirstOrDefault(b => b.IsSelected);
            if (book != null)
            {
                BookDetailWindow newBookWindow = new BookDetailWindow();
                newBookWindow.DataContext = book;
                bool? save = newBookWindow.ShowDialog();
                if (save == true)
                {
                    ReadingStatDataAccess dataAccess = new ReadingStatDataAccess();
                    dataAccess.UpdateBook(book);
                    this.Load(this.currentPage);
                }
            }
        }

        private void RemoveBook()
        {
            ReadingStatDataAccess dataAccess = new ReadingStatDataAccess();
            foreach (Book book in this.Books.Where(b => b.IsSelected))
            {
                dataAccess.RemoveBook(book);
            }
            this.Load(this.currentPage);
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
