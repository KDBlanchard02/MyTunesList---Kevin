using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class SingleService
    {
        private readonly Guid _singleId;

        public SingleService(Guid singleId)
        {
            _singleId = singleId;
        }

        public bool CreateSingle(SingleCreate model)
        {
            var entity =
                new SingleTrack()
                {
                    OwnerId = _singleId,
                    Title = model.Title,
                    Genre = model.Genre,
                    Artist_Band = model.Artist_Band,
                    ReleaseDate = model.ReleaseDate,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SingleTracks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SingleListItem> GetAllSingles()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SingleTracks
                        .Where(e => e.OwnerId == _singleId)
                        .Select(
                            e =>
                                new SingleListItem
                                {
                                    SingleId = e.SingleId,
                                    Title = e.Title,
                                    ReleaseDate = e.ReleaseDate,
                                    Genre = e.Genre,
                                    Artist_Band = e.Artist_Band,
                                }

                         );
                return query.ToArray();

            }
        }


        public SingleDetail GetSingleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SingleTracks
                        .Single(e => e.SingleId == id && e.OwnerId == _singleId);

                var reviews = (from x in ctx.SingleRatings where x.SingleId.Equals(id) select x).ToList();

                double avg = (from x in reviews select x.Rating).Average();

                return
                    new SingleDetail
                    {
                        SingleId = entity.SingleId,
                        Title = entity.Title,
                        Genre = entity.Genre,
                        Artist_Band = entity.Artist_Band,
                        AverageRating = avg,
                        ReleaseDate = entity.ReleaseDate,
                    };
            }
        }

        public bool UpdateSingle(SingleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SingleTracks
                        .Single(e => e.SingleId == model.SingleId && e.OwnerId == _singleId);

                entity.Title = model.Title;
                entity.Genre = model.Genre;
                entity.Artist_Band = model.Artist_Band;
                entity.ReleaseDate = model.ReleaseDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSingle(int singleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SingleTracks
                        .Single(e => e.SingleId == singleId && e.OwnerId == _singleId);

                ctx.SingleTracks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }

    
}

