using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using MyTunesList.Services;
using MyTunesList.Models;
using Microsoft.AspNet.Identity;

namespace MyTunesList.WebAPI.Controllers
{
    [Authorize]
    public class SingleTrackController : ApiController
    {
        public IHttpActionResult Get()
        {
            SingleService singleService = CreateSingleService();
            var singles = singleService.GetAllSingles();
            return Ok(singles);
        }

        public IHttpActionResult Get(int id)
        {
            SingleService singleService = CreateSingleService();
            var single = singleService.GetSingleById(id);
            return Ok(single);
        }

        public IHttpActionResult Post(SingleCreate single)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSingleService();

            if (!service.CreateSingle(single))
                return InternalServerError();

            return Ok();
        }

        private SingleService CreateSingleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var singleService = new SingleService(userId);
            return singleService;
        }
        public IHttpActionResult Put(SingleEdit single)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSingleService();

            if (!service.UpdateSingle(single))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSingleService();

            if (!service.DeleteSingle(id))
                return InternalServerError();

            return Ok();
        }
    }
}