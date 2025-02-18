using MovieApi.Application.Features.CQRSDesginPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesginPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery queries)
        {
            var values = await _movieContext.Movies.FindAsync(queries.MovieId);
            return new GetMovieByIdQueryResult
            {
                CoverImageUrl = values.CoverImageUrl,
                CreatedYear = values.CreatedYear,
                Description = values.Description,
                Duration = values.Duration,
                MovieId = values.MovieId,
                Rating = values.Rating,
                ReleaseDate = values.ReleaseDate,
                Status = values.Status,
                Title = values.Title
            };
        }
    }
}
