using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDApp.Models;

namespace DnDApp.Repositories
{
    public interface IEpisodeRepository
    {
        IEnumerable<Episode> GetEpisodes(bool bypassing = false);
        IEnumerable<Episode> GetEpisodes(int bookId);
        Episode GetEpisode(int EpisodeId);
        
        void CreateEpisode(Episode episode);
        void AddCharactersToEpisode(int id, string[] characterNames);


}
}
