using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class AlbumService
    {
        private readonly Guid _userId;

        public AlbumService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album()
            {
                AuthorId = _userId,
                Artist_Band = model.Artist_Band,
                AlbumTitle = model.AlbumTitle,
                ReleaseYear = model.ReleaseYear,
                SongList = model.SongList
            };

            using (var context = new ApplicationDbContext())
            {
                context.Albums.Add(entity);
                return context.SaveChanges() == 1;
            }
            
        }

        public AlbumDetail GetAlbumByAlbumId(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Albums
                        .Single(e => e.AlbumId == id);

                var reviews = (from x in context.AlbumRatings where x.AlbumId.Equals(id) select x).ToList();

                double avg = (from x in reviews select x.Rating).Average();

                return
                    new AlbumDetail
                    {
                        AlbumId = entity.AlbumId,
                        Artist = entity.Artist_Band,
                        AlbumTitle = entity.AlbumTitle,
                        ReleaseYear = entity.ReleaseYear,
                        SongList = entity.SongList,
                        AverageRating = avg
                    };
            }
        }

        public IEnumerable<AlbumListItem> GetAllAlbums()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context
                    .Albums
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                    e =>
                    new AlbumListItem
                    {
                        AlbumId = e.AlbumId,
                        Title = e.AlbumTitle,
                        Artist = e.Artist_Band,
                        ReleaseYear = e.ReleaseYear
                    });
                return query.ToArray();
            }
        }

        public bool UpdateAlbum(AlbumEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Albums
                        .Single(e => e.AlbumId == model.AlbumId && e.AuthorId == _userId);
                entity.Artist_Band = model.Artist;
                entity.AlbumTitle = model.AlbumTitle;
                entity.SongList = model.SongList;
                entity.ReleaseYear = model.ReleaseYear;

                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Albums
                        .Single(e => e.AlbumId == albumId && e.AuthorId == _userId);
                context.Albums.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
