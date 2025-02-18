using MovieApi.Application.Features.CQRSDesginPattern.Command.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHanler
    {
        private readonly MovieContext _movieContext;

        public RemoveCategoryCommandHanler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var values = await _movieContext.Categories.FindAsync(command.CategoryId);
            _movieContext.Categories.Remove(values);
            await _movieContext.SaveChangesAsync();
        }
    }
}
