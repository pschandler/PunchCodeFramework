using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PunchcodeStudios.Application.Features.CategoryGallery;
using PunchcodeStudios.Application.Features.CategoryGallery.Queries.GetCategoryGalleries;
using PunchcodeStudios.Application.Features.CategoryGallery.Commands.AddCategoryGallery;

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
        public async Task<IEnumerable<CategoryGalleryDTO>> GetAll()
        {
            var items = await _mediator.Send(new GetCategoryGalleriesQuery());
            return items;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> Put([FromBody] AddGalleryToCategoryCommand cmd)
        {
            try
            {
                var response = await _mediator.Send(cmd);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest(message);
            }
        }
    }
}
