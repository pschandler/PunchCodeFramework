using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PunchcodeStudios.Application.Features.Category;
using PunchcodeStudios.Application.Features.Category.Commands.CreateCategory;
using PunchcodeStudios.Application.Features.Category.Commands.DeleteCategory;
using PunchcodeStudios.Application.Features.Category.Commands.UpdateCategory;
using PunchcodeStudios.Application.Features.Category.Queries.GetCategories;
using PunchcodeStudios.Application.Features.Category.Queries.GetCategoriesById;
using PunchcodeStudios.Application.Features.Category.Queries.GetCategoriesByName;

namespace PunchcodeStudios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var items = await _mediator.Send(new GetCategoriesQuery());
            return items.OrderBy(o => o.DateCreated);
        }

        [HttpGet("id/{id}")]
        [AllowAnonymous]
        public async Task<CategoryDTO> GetById(Guid id)
        {
            var item = await _mediator.Send(new GetCategoryByIdQuery(id));
            return item;
        }

        [HttpGet("name/{name}")]
        [AllowAnonymous]
        public async Task<CategoryDTO> GetByName(string name)
        {
            var item = await _mediator.Send(new GetCategoryByNameQuery(name));
            return item;
        }

        // POST api/<GalleryController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Post(CreateCategoryCommand gallery)
        {
            Guid response = await _mediator.Send(gallery);
            return Ok(response);
        }

        // PUT api/<GalleryController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> Put([FromBody] UpdateCategoryCommand gallery)
        {
            var response = await _mediator.Send(gallery);
            return Ok(response);
        }

        // DELETE api/<GalleryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
