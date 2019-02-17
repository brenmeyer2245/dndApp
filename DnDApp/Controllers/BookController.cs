using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDApp.Repositories;
using DnDApp.Models;
using DnDApp.Services;
using DnDApp.Models.DnDViewModels;

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
            ViewBag.AudioPlayer = new Models.DnDViewModels.AudioPlayer() { EpisodeName = "TestEpi", AudioFileUrl = "Test" };

            return View(_booksRepo.GetBooks());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (book.Series != "Veil of Spears" && book.Series != "Blood Wet Sands") return RedirectToAction("Index", "Episode");
                var result = _bookService.CreateBook(book);
                return RedirectToAction("Index");
            } catch(Exception ee)
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult Edit(int id)
        {
            var book = _bookService.GetBook(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            var editedBook = _bookService.EditBook(book);
            if (editedBook == null)
            {
                RedirectToAction("NotFound", "ErrorHandler");
            }

            return RedirectToAction("ChapterIndex", "Episode", new { id = editedBook.Id});
        }
    }
}
