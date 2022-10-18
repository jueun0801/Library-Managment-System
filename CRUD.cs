using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6._4
{
    interface CRUD
    {
        void AddRecord(Book book);
        void DeleteRecord(Book book);   
        ICollection<Book> GetAllRecords();
        Book FindBook(string ISBN);
        void UpdateRecord(string ISBN, Book book);
    }
    class BookRepository : CRUD
    {
        BookEntities entities;
        public BookRepository()
        {
            entities = new BookEntities();
        }
        public void AddRecord(Book book)
        {
            entities.Books.Add(book);
            entities.SaveChanges();
        }

        public void DeleteRecord(Book book)
        {
            entities.Books.Remove(book);
            entities.SaveChanges();
        }

        public Book FindBook(string ISBN)
        {
            return entities.Books.Find(ISBN);
        }

        public ICollection<Book> GetAllRecords()
        {
            return entities.Books.ToList();
        }

        public void UpdateRecord(string ISBN, Book book)
        {
            var booktoupdate = entities.Books.Find(ISBN);
            booktoupdate.ISBN = book.ISBN;
            booktoupdate.BookName = book.BookName;
            booktoupdate.Author = book.Author;
            booktoupdate.Description = book.Description;
            booktoupdate.ReleaseDate = book.ReleaseDate;
            booktoupdate.Copies = book.Copies;
            booktoupdate.Genre = book.Genre;
            entities.SaveChanges();

        }
    }
}
