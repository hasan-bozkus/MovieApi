using MovieApi.Application.Features.CQRSDesginPattern.Command.MovieCommnands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public RemoveMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async void Handle(RemoveMovieCommand command)
        {
            var values = await _movieContext.Movies.FindAsync(command.MovieId);
            _movieContext.Movies.Remove(values);
            await _movieContext.SaveChangesAsync();
        }
    }
}
