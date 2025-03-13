using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Command.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public CreateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _movieContext.Casts.Add(new Cast()
            {
                Title = request.Title,
                Namee = request.Name,
                Surname = request.Surname,
                ImageUrl = request.ImageUrl,
                Overview = request.Overview,
                Biography = request.Biography
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
