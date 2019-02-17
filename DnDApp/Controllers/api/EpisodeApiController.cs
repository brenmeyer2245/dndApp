using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DnDApp.Services;

namespace DnDApp.Controllers.api
{
    public class EpisodeApiController : ApiController
    {
        private readonly IEpisodeService _episodeService;
        public EpisodeApiController(IEpisodeService episodeService)
        {
           _episodeService = episodeService;
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage AddCharactersToEpisode(int episodeId, string charactersList)
        {
            //break up list of characters into an array 
            string [] characters = charactersList.Split(',');

            //call service for add 
            _episodeService.AddCharactersToEpisode(episodeId, characters);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
