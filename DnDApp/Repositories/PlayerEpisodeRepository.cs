using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.DataBase;
using DnDApp.Models;
namespace DnDApp.Repositories
{
    public class PlayerEpisodeRepository
    {

        private readonly DnDAppDbContext _db = new DnDAppDbContext();


        public IEnumerable<PlayerEpisode> GetPlayerEpisodes()
        {
            return _db.PlayerEpisodes.ToList();
        }
    }
}