
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesginPattern.Results.MovieResults;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieWithCategoryQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieWithCategoryQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetMovieWithCategoryQueryResult>> Handle()
        {
            var values = await _movieContext.Movies.Include(x=> x.Category).ToListAsync();
            return values.Select(x => new GetMovieWithCategoryQueryResult
            {
                MovieId = x.MovieId,
                Title = x.Title,
                Description = x.Description,
                CoverImageUrl = x.CoverImageUrl,
                Duration = x.Duration,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName
            }).ToList();
        }
    }
}
