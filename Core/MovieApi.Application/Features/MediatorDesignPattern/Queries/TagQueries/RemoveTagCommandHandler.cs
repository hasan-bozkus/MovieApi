using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Command.TagCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class RemoveTagCommandHandler : IRequestHandler<RevmoveTagCommand>
    {
        private readonly MovieContext _movieContext;

        public RemoveTagCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RevmoveTagCommand request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Tags.FindAsync(request.TagId);
            _movieContext.Tags.Remove(values);
            await _movieContext.SaveChangesAsync();
        }
    }
}
