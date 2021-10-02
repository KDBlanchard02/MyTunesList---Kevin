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
    public class AlbumRatingController : ApiController
    {
        private AlbumRatingService CreateAlbumRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumRatingService(userId);
            return albumService;
        }

        [HttpGet]
        public IHttpActionResult GetRatingsByAlbumID(int albumId)
        {
            AlbumRatingService albumService = CreateAlbumRatingService();
            var albums = albumService.GetAlbumRatingsForAnAlbumByAlbumId(albumId);
            return Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult GetRatingByRatingID(int ratingId)
        {
            AlbumRatingService albumService = CreateAlbumRatingService();
            var albums = albumService.GetAlbumRatingByAlbumRatingId(ratingId);
            return Ok(albums);
        }

        [HttpPost]
        public IHttpActionResult Post(AlbumRatingCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumRatingService();

            if (!service.CreateAlbumRating(model))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(AlbumRatingEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumRatingService();

            if (!service.EditAlbumRating(model))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumRatingService();

            if (!service.DeleteAlbumRating(id))
                return InternalServerError();

            return Ok();
        }
    }
}
