using MovieApi.Application.Features.CQRSDesignPattern.Command.SeriesCommand;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class RemoveSeriesCommandHandler
    {
        private readonly MovieContext _movieContext;
        public RemoveSeriesCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(RemoveSeriesCommand command)
        {
            var series = await _movieContext.Serieses.FindAsync(command.SeriesId);
            if (series != null)
            {
                _movieContext.Serieses.Remove(series);
                await _movieContext.SaveChangesAsync();
            }
        }
    }
}
