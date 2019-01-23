using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Web.Mvc;
using DnDApp.Repositories;


namespace DnDApp.Controllers.api
{
    public class CharacterApiController : ApiController
    {
        private readonly EFCharacterRepository characterRepository = new EFCharacterRepository();
        // GET: CharacterApi
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ChangePlayerNameBrendan(int id)
        {
        
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}