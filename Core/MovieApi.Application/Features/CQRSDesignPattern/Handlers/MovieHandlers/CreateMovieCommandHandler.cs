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
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async void Handle(CreateMovieCommand command)
        {
            var movie = new Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Rating = command.Rating,
                Status = command.Status,
                Title = command.Title,
                Duration = command.Duration,
                ReleaseDate = command.ReleaseDate
            };
            await _movieContext.Movies.AddAsync(movie);
            await _movieContext.SaveChangesAsync();
        }
    }
}
