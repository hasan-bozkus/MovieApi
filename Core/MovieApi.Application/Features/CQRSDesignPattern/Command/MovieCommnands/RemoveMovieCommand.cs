using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesginPattern.Command.MovieCommnands
{
    public class RemoveMovieCommand
    {
        public int MovieId { get; set; }

        public RemoveMovieCommand(int movieId)
        {
            MovieId = movieId;
        }
    }
}
