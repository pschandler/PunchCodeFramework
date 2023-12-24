using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PunchcodeStudios.Application.Features.GalleryCategory;
using PunchcodeStudios.Application.Features.GalleryCategory.Commands.CreateGalleryCategory;
using PunchcodeStudios.Application.Features.GalleryCategory.Commands.DeleteGalleryCategory;
using PunchcodeStudios.Application.Features.GalleryCategory.Commands.UpdateGalleryCategory;
using PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategories;
using PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategoriesById;
using PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategoriesByName;

namespace PunchcodeStudios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GalleryCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GalleryCategoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<GalleryCategoryDTO>> GetAll()
        {
            var items = await _mediator.Send(new GetGalleryCategoriesQuery());
            return items.OrderBy(o => o.DateCreated);
        }

        [HttpGet("id/{id}")]
        [AllowAnonymous]
        public async Task<GalleryCategoryDTO> GetById(Guid id)
        {
            var item = await _mediator.Send(new GetGalleryCategoryByIdQuery(id));
            return item;
        }

        [HttpGet("name/{name}")]
        [AllowAnonymous]
        public async Task<GalleryCategoryDTO> GetByName(string name)
        {
            var item = await _mediator.Send(new GetGalleryCategoryByNameQuery(name));
            return item;
        }

        // POST api/<GalleryController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Post(CreateGalleryCategoryCommand gallery)
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
        public async Task<ActionResult<bool>> Put([FromBody] UpdateGalleryCategoryCommand gallery)
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
            var command = new DeleteGalleryCategoryCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
