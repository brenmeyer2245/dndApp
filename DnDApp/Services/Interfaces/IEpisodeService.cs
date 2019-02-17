using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDApp.Models;

namespace DnDApp.Services
{
    public interface IEpisodeService
    {
        IEnumerable<Episode> GetEpisodes(bool bypassing = false);
        IEnumerable<Episode> GetEpisodes(int bookId);
        Episode GetEpisode(int id);
        void CreateEpisode(Episode episode);
        void AddCharactersToEpisode(int id, string[] characterNames);

    }
}
