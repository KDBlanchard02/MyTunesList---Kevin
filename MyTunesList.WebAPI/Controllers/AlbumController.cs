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
    public class AlbumController : ApiController
    {
        private AlbumService CreateAlbumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumService(userId);
            return albumService;
        }

        public IHttpActionResult Get()
        {
            AlbumService albumService = CreateAlbumService();
            var albums = albumService.GetAllAlbums();
            return Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            AlbumService albumService = CreateAlbumService();
            var album = albumService.GetAlbumByAlbumId(id);
            return Ok(album);
        }
        
        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }
        
        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }
    }
}
