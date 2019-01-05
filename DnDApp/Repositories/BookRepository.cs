using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.DataBase;
using DnDApp.Models;
using DnDApp.Common;
namespace DnDApp.Repositories
{
    public class BookRepository
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


    }
}