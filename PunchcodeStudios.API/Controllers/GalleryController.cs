﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchcodeStudios.Application.Features.Gallery;
using PunchcodeStudios.Application.Features.Gallery.Commands.CreateGallery;
using PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery;
using PunchcodeStudios.Application.Features.Gallery.Commands.UpdateGallery;
using PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleries;
//using PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleriesByCategoryName;
//using PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleriesByTypeName;
using PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleryById;
using PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleryByName;

namespace PunchcodeStudios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GalleryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GalleryDTO>> GetAll()
        {
            var galleries = await _mediator.Send(new GetGalleriesQuery());
            return galleries;
        }

        [HttpGet("id/{id}")]
        public async Task<GalleryDTO> GetById(Guid id)
        {
            var gallery = await _mediator.Send(new GetGalleryByIdQuery(id));
            return gallery;
        }

        [HttpGet("name/{name}")]
        public async Task<GalleryDTO> GetByName(string name)
        {
            var gallery = await _mediator.Send(new GetGalleryByNameQuery(name));
            return gallery;
        }

        // POST api/<GalleryController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Post(CreateGalleryCommand gallery)
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
        public async Task<ActionResult<bool>> Put([FromBody]UpdateGalleryCommand gallery)
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
            var command = new DeleteGalleryCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
