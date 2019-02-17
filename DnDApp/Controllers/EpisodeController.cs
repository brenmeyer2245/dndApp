using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDApp.Models;
using DnDApp.Repositories;
using DnDApp.Services;

namespace DnDApp.Controllers
{
    public class EpisodeController : Controller
    {

        private readonly IEpisodeService _episodeService;
        private readonly IBookService _bookService;
        private readonly ICharacterService _characterService;

        public EpisodeController(IEpisodeService episodeService, IBookService bookService, ICharacterService characterService)
        {
            _episodeService = episodeService;
            _bookService = bookService;
            _characterService = characterService;
        }

        // GET: Episode
        public ActionResult Index()
        {
            return View(_episodeService.GetEpisodes());
        }


        public ActionResult ChaptersIndex(int id)
        {

            var episodes = _episodeService.GetEpisodes(id);
            ViewBag.BookName = _bookService.GetBook(id).BookName;
            return View(episodes);
        }
        //// GET: Episode/Details/5
        public ActionResult Details(int id)
        {
            return View(_episodeService.GetEpisode(id));
        }

        // GET: Episode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Episode/Create
        [HttpPost]
        public ActionResult Create(Episode episode)
        {
            try
            {
                _episodeService.CreateEpisode(episode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Episode/Edit/5
        public ActionResult Edit(int id)
        {
            var bookList = _bookService.GetBooks();
            ViewData["selectList"] = new List<SelectListItem>(bookList.Select(_ => new SelectListItem { Text = _.BookName, Value = _.Id.ToString() }));
            ViewBag.BookList = bookList;

            var characterList = _characterService.GetCharacters();
            var episode = _episodeService.GetEpisode(id);
            ViewBag.SelectedCharacterNames = episode.PlayerEpisodes.Select(_ => _.PartyMember.Name);
            ViewBag.CharactersInEpisode = new List<SelectListItem>(characterList.Select(character => new SelectListItem { Text = character.Name }));
           

            return View(episode);
        }

        // POST: Episode/Edit/5
        [HttpPost]
        public ActionResult Edit(Episode episode)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Episode/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Episode/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
