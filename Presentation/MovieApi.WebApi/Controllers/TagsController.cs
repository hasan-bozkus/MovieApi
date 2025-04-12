using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Command.TagCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using System.Threading.Tasks;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            var values = await _mediator.Send(new GetTagQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand createTagCommand)
        {
             await _mediator.Send(createTagCommand);
            return Ok("Ekleme işlemi başrılı");
        }

        [HttpGet("GetTag")]
        public async Task<IActionResult> GetTag(int id)
        {
            var values = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand updateTagCommand)
        {
            await _mediator.Send(updateTagCommand);
            return Ok("Güncelleme işlemi başarılı");
        }

    }
}
