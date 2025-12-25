using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesByIdQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetSeriesByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery query)
        {
            var item = await _movieContext.Serieses.FindAsync(query.SeriesId);

            return new GetSeriesByIdQueryResult
            {
                SeriesId = item!.SeriesId,
                Title = item.Title,
                CoverImageUrl = item.CoverImageUrl,
                Rating = item.Rating,
                Description = item.Description,
                FirstAirDate = item.FirstAirDate,
                CreatedYear = item.CreatedYear,
                AverageEpisodeDuration = item.AverageEpisodeDuration,
                SeasonCount = item.SeasonCount,
                EpisodeCount = item.EpisodeCount,
                Status = item.Status,
                CategoryId = item.CategoryId
            };

        }
    }
}
