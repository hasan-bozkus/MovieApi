using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesginPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var values = await _movieContext.Movies.ToListAsync();
            return values.Select(x => new GetMovieQueryResult
            {
                MovieId = x.MovieId,
                Title = x.Title,
                Description = x.Description,
                CoverImageUrl = x.CoverImageUrl,
                Duration = x.Duration,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status
            }).ToList();
        }
    }
}
