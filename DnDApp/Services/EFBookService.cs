using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.Repositories;

namespace DnDApp.Services
{
    public class EFBookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        
        public EFBookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks(bool bypassing = false)
        {
            return _bookRepository.GetBooks(bypassing);
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }
    }
}