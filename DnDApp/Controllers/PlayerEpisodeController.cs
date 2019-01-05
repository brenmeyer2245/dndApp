using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDApp.Repositories;
using DnDApp.Models;

namespace DnDApp.Controllers
{
    public class PlayerEpisodeController : Controller
    {
    private readonly PlayerEpisodeRepository _playerEpisodeRepo = new PlayerEpisodeRepository();
        // GET: PlayerEpisode
        public ActionResult Index()
        {
            return View(_playerEpisodeRepo.GetPlayerEpisodes());
            
        }
    }
}