using MovieApi.Application.Features.CQRSDesginPattern.Command.MovieCommnands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async void Handle(UpdateMovieCommand command)
        {
            var result = await _movieContext.Movies.FindAsync(command.MovieId);
            var movie = new Movie
            {
                CoverImageUrl = result.CoverImageUrl,
                CreatedYear = result.CreatedYear,
                Description = result.Description,
                Rating = result.Rating,
                Status = result.Status,
                Title = result.Title,
                Duration = result.Duration,
                ReleaseDate = result.ReleaseDate
            };
            _movieContext.Movies.Update(movie);
            await _movieContext.SaveChangesAsync();
        }
    }
}
