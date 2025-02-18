using MovieApi.Application.Features.CQRSDesginPattern.Command.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var values = await _movieContext.Categories.FindAsync(command.CategoryId);
            var category = new Category
            {
                CategoryName = values.CategoryName
            };
            _movieContext.Categories.Update(category);
            await _movieContext.SaveChangesAsync();
        }
    }
}
