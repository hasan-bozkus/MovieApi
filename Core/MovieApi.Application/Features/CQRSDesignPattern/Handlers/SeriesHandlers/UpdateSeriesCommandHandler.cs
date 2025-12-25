using MovieApi.Application.Features.CQRSDesignPattern.Command.SeriesCommand;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class UpdateSeriesCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateSeriesCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateSeriesCommand command)
        {
            var series = await _movieContext.Serieses.FindAsync(command.SeriesId);
            if (series != null)
            {
                series.Title = command.Title;
                series.CoverImageUrl = command.CoverImageUrl;
                series.Rating = command.Rating;
                series.Description = command.Description;
                series.FirstAirDate = command.FirstAirDate;
                series.CreatedYear = command.CreatedYear;
                series.AverageEpisodeDuration = command.AverageEpisodeDuration;
                series.SeasonCount = command.SeasonCount;
                series.EpisodeCount = command.EpisodeCount;
                series.Status = command.Status;
                series.CategoryId = command.CategoryId;

                _movieContext.Serieses.Update(series);
                await _movieContext.SaveChangesAsync();
            }
        }
    }
}
