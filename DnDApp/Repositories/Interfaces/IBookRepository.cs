using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDApp.Models;

namespace DnDApp.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks(bool bypassing = false);
        Book GetBook(int id);

    }
}
