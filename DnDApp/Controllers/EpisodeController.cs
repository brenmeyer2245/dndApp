using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDApp.Repositories;

namespace DnDApp.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly BookRepository bookRepository = new BookRepository();
        private readonly EpisodeRepository _episodeRepo = new EpisodeRepository();
        // GET: Episode
        public ActionResult Index()
        {
            return View(_episodeRepo.GetEpisodes());
        }


        public ActionResult ChaptersIndex(int id)
        {

            var episodes = _episodeRepo.GetEpisodes(id);
            ViewBag.BookName = bookRepository.GetBook(id).BookName;
            return View(episodes);
        }
        // GET: Episode/Details/5
        public ActionResult Details(int id)
        {
            return View(_episodeRepo.GetEpisode(id));
        }

        // GET: Episode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Episode/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Episode/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
