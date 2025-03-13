using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Command.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _movieContext;

        public RemoveCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.FindAsync(request.CastId);
            _movieContext.Casts.Remove(values);
            await _movieContext.SaveChangesAsync();
        }
    }
}
