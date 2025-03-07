using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesginPattern.Command.CategoryCommands;
using MovieApi.Application.Features.CQRSDesginPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly RemoveCategoryCommandHanler _removeCategoryCommandHanler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, RemoveCategoryCommandHanler removeCategoryCommandHanler, UpdateCategoryCommandHandler updateCategoryCommandHandler, CreateCategoryCommandHandler createCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _removeCategoryCommandHanler = removeCategoryCommandHanler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await _getCategoryQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategori ekleme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Kategori güncelleme işlemi başarılı!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHanler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kategori silme işlemi başarılı!");
        }

        [HttpGet("GetCategry/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
    }
}
