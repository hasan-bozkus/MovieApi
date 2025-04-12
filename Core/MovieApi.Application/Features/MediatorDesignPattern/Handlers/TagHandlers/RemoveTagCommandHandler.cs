using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Command.TagCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly MovieContext _movieContext;
        public RemoveTagCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Tags.FindAsync(request.TagId);
            _movieContext.Tags.Remove(values);
            await _movieContext.SaveChangesAsync();
        }
    }
}
