using MyTunesList.Data;
using MyTunesList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Services
{
    public class SingleRatingService
    {
        private readonly Guid _userId;

        public SingleRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSingleRating(SingleRatingCreate model)
        {
            var entity = new SingleRating()
            {
                AuthorId = _userId,
                Rating = model.Rating,
                SingleId = model.SingleId,
                ReviewComment = model.ReviewComment,
                DateCreated = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SingleRatings.Add(entity);
               
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<SingleRatingListItem> GetSingleRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .SingleRatings
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                    e =>
                    new SingleRatingListItem
                    {
                        SingleRatingId = e.SingleRatingId,
                        SingleId = e.SingleId,
                        SingleTrackTitle = e.SingleTrack.Title,
                        Rating = e.Rating,
                        ReviewComment = e.ReviewComment,
                        DateCreated = e.DateCreated,
                        DateModified = e.DateModified
                    }
                    );
                return query.ToArray();
            }
        }

        public SingleRatingDetail GetSingleRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SingleRatings
                    .Single(e => e.SingleRatingId == id && e.AuthorId == _userId);
                return
                    new SingleRatingDetail
                    {
                        SingleRatingId = entity.SingleRatingId,
                        SingleId = entity.SingleId,
                        SingleTrackTitle = entity.SingleTrack.Title,
                        Rating = entity.Rating,
                        ReviewComment = entity.ReviewComment,
                        DateCreated = entity.DateCreated,
                        DateModified = entity.DateModified,
                    };
            }
        }

        public bool EditSingleRating(SingleRatingEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .SingleRatings
                        .Single(e => e.SingleRatingId == model.SingleRatingId && e.AuthorId == _userId);
                entity.SingleRatingId = model.SingleRatingId;
                entity.Rating = model.Rating;
                entity.ReviewComment = model.ReviewComment;
                entity.DateModified = DateTimeOffset.UtcNow;

                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteSingleRating(int singleRatingId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .SingleRatings
                        .Single(e => e.SingleRatingId == singleRatingId && e.AuthorId == _userId);
                context.SingleRatings.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
