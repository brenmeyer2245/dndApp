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
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: Character
        public ActionResult Index()
        {
            return View(_characterService.GetCharacters());
        }

        // GET: Character/Details/5
        public ActionResult Details(int id)
        {
            return View(_characterService.GetCharacter(id));
        }

        // GET: Character/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Character/Create
        [HttpPost]
        public ActionResult Create(PartyMember character)
        {
            try
            {
                _characterService.CreateCharacter(character);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int id)
        {
            var characterToEdit = _characterService.GetCharacter(id);
            return View(characterToEdit);
        }

        // POST: Character/Edit/5
        [HttpPost]
        public ActionResult Edit(PartyMember character)
        {

               var editedCharacter = _characterService.EditCharacter(character);
                if (editedCharacter == null)
                {
                return RedirectToAction("NotFound", "ErrorHandler");
                }
                return RedirectToAction("Details", new { id = character.Id});
     
        }

        // GET: Character/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Character/Delete/5
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
