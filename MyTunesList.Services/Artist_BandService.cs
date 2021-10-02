using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class Artist_BandService
    {
        private readonly Guid _userId;

        public Artist_BandService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist_Band(Artist_BandCreate model)
        {
            var entity = new Artist_Band()
            {
                AuthorId = _userId,
                Name = model.Name,
                FormationYear = model.FormationYear,
                Location = model.Location,
                Description = model.Description,
                Genre = model.Genre
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artist_Bands.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Artist_BandListItem> GetArtist_Bands()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Artist_Bands
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                    e =>
                    new Artist_BandListItem
                    {
                        Artist_BandId = e.Artist_BandId,
                        Name = e.Name,
                        FormationYear = e.FormationYear,
                        Location = e.Location,
                        Description = e.Description,
                        Genre = e.Genre
                    }
                    );
                return query.ToArray();
            }
        }

        public Artist_BandDetail GetArtist_BandById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artist_Bands
                    .Single(e => e.Artist_BandId == id && e.AuthorId == _userId);
                return
                    new Artist_BandDetail
                    {
                        Artist_BandId = entity.Artist_BandId,
                        Name = entity.Name,
                        FormationYear = entity.FormationYear,
                        Location = entity.Location,
                        Description = entity.Description,
                        Genre = entity.Genre
                    };
            }
        }

        public bool UpdateArtist_Band(Artist_BandEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Artist_Bands
                    .Single(e => e.Artist_BandId == model.Artist_BandId && e.AuthorId == _userId);

                entity.Name = model.Name;
                entity.FormationYear = model.FormationYear;
                entity.Location = model.Location;
                entity.Description = model.Description;
                entity.Genre = model.Genre;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist_Band(int artist_BandId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artist_Bands
                    .Single(e => e.Artist_BandId == artist_BandId && e.AuthorId == _userId);

                ctx.Artist_Bands.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
