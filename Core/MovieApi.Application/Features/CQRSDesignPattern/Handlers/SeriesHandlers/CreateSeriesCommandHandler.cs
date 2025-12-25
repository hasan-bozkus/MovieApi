using MovieApi.Application.Features.CQRSDesignPattern.Command.SeriesCommand;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateSeriesCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateSeriesCommand command)
        {
            var series = new Series
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                FirstAirDate = command.FirstAirDate,
                CreatedYear = command.CreatedYear,
                AverageEpisodeDuration = command.AverageEpisodeDuration,
                SeasonCount = command.SeasonCount,
                EpisodeCount = command.EpisodeCount,
                Status = command.Status,
                CategoryId = command.CategoryId
            };
            await _movieContext.Serieses.AddAsync(series);
            await _movieContext.SaveChangesAsync();
        }
    }
}
