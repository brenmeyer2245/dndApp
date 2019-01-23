using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDApp.Repositories;
using DnDApp.Models;
using DnDApp.Services;

namespace DnDApp.Controllers
{
    public class BookController : Controller
    {

        private readonly CurrentUserService userService = new CurrentUserService();
        private readonly EFBookRepository _booksRepo = new EFBookRepository();
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        // GET: Book
        public ActionResult Index()
        {
            return View(_booksRepo.GetBooks());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
