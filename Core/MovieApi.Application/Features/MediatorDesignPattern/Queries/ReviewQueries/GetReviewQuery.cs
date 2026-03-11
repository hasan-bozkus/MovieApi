using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.ReviewResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.ReviewQueries
{
    public class GetReviewQuery : IRequest<List<GetReviewQueryResult>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
