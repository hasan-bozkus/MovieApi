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
    public class GetSeriesWithCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetSeriesWithCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetSeriesWithCategoryQueryResult>> Handle()
        {
            var values = await _context.Serieses.Include(x => x.Category).ToListAsync();
            return values.Select(x => new GetSeriesWithCategoryQueryResult
            {
                SeriesId = x!.SeriesId,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                FirstAirDate = x.FirstAirDate,
                CreatedYear = x.CreatedYear,
                AverageEpisodeDuration = x.AverageEpisodeDuration,
                SeasonCount = x.SeasonCount,
                EpisodeCount = x.EpisodeCount,
                Status = x.Status,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName
            }).ToList();
        }
    }
}
