using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetSeriesQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetSeriesQueryResult>> Handle()
        {
            var values = await _movieContext.Serieses.ToListAsync();
            List<GetSeriesQueryResult> results = new List<GetSeriesQueryResult>();
            foreach (var item in values)
            {
                results.Add(new GetSeriesQueryResult
                {
                    SeriesId = item.SeriesId,
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
                });
            }
            return results;
        }
    }
}
