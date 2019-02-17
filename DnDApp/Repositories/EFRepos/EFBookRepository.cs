using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.DataBase;
using DnDApp.Models;
using DnDApp.Common;
namespace DnDApp.Repositories
{
    public class EFBookRepository : IBookRepository
    {

        private readonly DnDAppDbContext _db = new DnDAppDbContext();

        public IEnumerable<Book> GetBooks(bool bypassing = false)
        {
            if (!bypassing && HttpRuntime.Cache[CacheKeys.AllBooks] is IEnumerable<Book> bookList)
            {
                return bookList;
            }

            bookList = _db.Books.ToList();
            HttpRuntime.Cache.Insert(CacheKeys.AllBooks, bookList, null, DateTime.Now.Add(CacheExpirations.Books), TimeSpan.Zero);
            return bookList;
        }

        public Book GetBook(int id)
        {
            return _db.Books.SingleOrDefault(_ => _.Id == id);
        }

        public bool CreateBook(Book book)
        {
            //check for admin status or user is logged in 
            try
            {
                _db.Books.Add(book);
                _db.SaveChanges();

                HttpRuntime.Cache.Remove(CacheKeys.AllBooks);

                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
                return false;
            }
        }

        public Book EditBook(Book book)
        {

            var bookToEdit = _db.Books.SingleOrDefault(_ => _.Id == book.Id);
            if (bookToEdit == null)
            {
                return null;
            }
            if (book.Series != "Blood Wet Sands" && book.Series != "Veil of Spears")
            {
                return null;
            }
            bookToEdit.BookName = book.BookName;
            bookToEdit.Series = book.Series;
            _db.SaveChanges();
            HttpRuntime.Cache.Remove(CacheKeys.AllBooks);
            return bookToEdit;
        }
    }
}