using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.Repositories;

namespace DnDApp.Services
{
    public class EFEpisodeService : IEpisodeService 
    {
        private readonly IEpisodeRepository _episodeRepository;
        public EFEpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public Episode GetEpisode(int id)
        {
           return _episodeRepository.GetEpisode(id);

        }

        public IEnumerable<Episode> GetEpisodes(bool bypassing = false)
        {
            return _episodeRepository.GetEpisodes(bypassing);
                
        }

        public IEnumerable<Episode> GetEpisodes(int bookId)
        {
           return _episodeRepository.GetEpisodes(bookId);
        }

        public void CreateEpisode(Episode episode)
        {
            _episodeRepository.CreateEpisode(episode);
        }

        public void AddCharactersToEpisode(int id, string[] characterNames)
        {
            _episodeRepository.AddCharactersToEpisode(id, characterNames);
        }

    }
}