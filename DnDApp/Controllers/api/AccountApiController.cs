using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DnDApp.Services;
namespace DnDApp.Controllers.api
{
    public class AccountApiController : ApiController
    {
        private readonly CurrentUserService currentUserService = new CurrentUserService();
        [System.Web.Http.HttpGet]
        public HttpResponseMessage SignOut()
        {
            currentUserService.ClearCurrentUser();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        // PUT: api/AccountApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AccountApi/5
        public void Delete(int id)
        {
        }
    }
}
