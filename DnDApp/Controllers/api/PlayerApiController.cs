using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DnDApp.Models.DnDViewModels;
using DnDApp.Services;

namespace DnDApp.Controllers.api
{
    public class PlayerApiController : ApiController
       
    {
        private readonly CurrentUserService currentUserService = new CurrentUserService();
        private readonly IAudioPlayerService _audioPlayerService;

        public PlayerApiController(IAudioPlayerService audioPlayerService)
        {
            _audioPlayerService = audioPlayerService;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage ChangeEpisode(string url, string episodeTitle)
        {
            _audioPlayerService.updateAudioUrl(url, episodeTitle);
           
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}