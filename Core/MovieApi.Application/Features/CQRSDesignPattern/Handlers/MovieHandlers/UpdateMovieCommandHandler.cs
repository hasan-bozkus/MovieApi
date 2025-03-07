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

        public async Task Handle(UpdateMovieCommand command)
        {
            var result = await _movieContext.Movies.FindAsync(command.MovieId);
            result.CoverImageUrl = command.CoverImageUrl;
            result.CreatedYear = command.CreatedYear;
            result.Description = command.Description;
            result.Rating = command.Rating;
            result.Status = command.Status;
            result.Title = command.Title;
            result.Duration = command.Duration;
            result.ReleaseDate = command.ReleaseDate;
            _movieContext.Movies.Update(result);
            await _movieContext.SaveChangesAsync();
        }
    }
}
