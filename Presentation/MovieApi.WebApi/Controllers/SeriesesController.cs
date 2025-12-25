using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Command.SeriesCommand;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

namespace SerieseApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {
        private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        private readonly GetSeriesQueryHandler _getSerieseQuryHandler;
        private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
        private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;
        private readonly RemoveSeriesCommandHandler _removeSeriesCommandHandler;

        public SeriesesController(GetSeriesByIdQueryHandler getSeriesByIdQueryHandler, GetSeriesQueryHandler getSerieseQuryHandler, CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, RemoveSeriesCommandHandler removeSeriesCommandHandler)
        {
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _getSerieseQuryHandler = getSerieseQuryHandler;
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;
            _removeSeriesCommandHandler = removeSeriesCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var value = await _getSerieseQuryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
            await _createSeriesCommandHandler.Handle(command);
            return Ok("Dizi ekleme işlemi başarılı.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _removeSeriesCommandHandler.Handle(new RemoveSeriesCommand(id));
            return Ok("Dizi silme işlemi başarılı.");
        }

        [HttpGet("GetSeriese")]
        public async Task<IActionResult> GetSeriese(int id)
        {
            var value = await _getSeriesByIdQueryHandler.Handle(new MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries.GetSeriesByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeriese(UpdateSeriesCommand command)
        {
            await _updateSeriesCommandHandler.Handle(command);
            return Ok("Dizi güncelleme işlemi başarılı.");
        }
    }
}
