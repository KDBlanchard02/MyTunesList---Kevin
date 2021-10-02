using Microsoft.AspNet.Identity;
using MyTunesList.Models;
using MyTunesList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTunesList.WebAPI.Controllers
{
    [Authorize]
    public class SingleRatingController : ApiController
    {
        private SingleRatingService CreateSingleRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var singleRatingService = new SingleRatingService(userId);
            return singleRatingService;
        }

        public IHttpActionResult Get()
        {
            SingleRatingService singleRatingService = CreateSingleRatingService();
            var singleRatings = singleRatingService.GetSingleRatings();
            return Ok(singleRatings);
        }

        public IHttpActionResult Post(SingleRatingCreate singleRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSingleRatingService();

            if (!service.CreateSingleRating(singleRating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            SingleRatingService singleRatingService = CreateSingleRatingService();
            var singleRating = singleRatingService.GetSingleRatingById(id);
            return Ok(singleRating);
        }

        public IHttpActionResult Put(SingleRatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSingleRatingService();

            if (!service.EditSingleRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSingleRatingService();

            if (!service.DeleteSingleRating(id))
                return InternalServerError();

            return Ok();
        }
    }
}
