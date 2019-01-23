using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.DataBase;
using DnDApp.Common;


namespace DnDApp.Repositories
{
    
    public class EFEpisodeRepository : IEpisodeRepository
    {
        private readonly DnDAppDbContext _db = new DnDAppDbContext();


        public IEnumerable<Episode> GetEpisodes(bool bypassing = false)
        {
            if (!bypassing && HttpRuntime.Cache[CacheKeys.AllEpisodes] is IEnumerable<Episode> episodesList)
                return episodesList;

            episodesList =  _db.Episodes.ToList();
            HttpRuntime.Cache.Insert(CacheKeys.AllEpisodes, episodesList, null, DateTime.Now.Add(CacheExpirations.Episodes), TimeSpan.Zero);

            return episodesList;
        }

        /**
         * Get Chapters by Book
         * */
        public IEnumerable<Episode> GetEpisodes(int bookId)
        {
            return _db.Episodes
                .Where(_ => _.BookId == bookId)
                .ToList();
        }

        public Episode GetEpisode(int EpisodeId)
        {
            return _db.Episodes
                .SingleOrDefault(_ => _.Id == EpisodeId);
        }

    }
}