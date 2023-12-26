using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;
using PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {

        private readonly ICategoryRepository _repo;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository repo)
        {
            this._repo = repo;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // TODO Validate incoming data

            var item = await _repo.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Category), request.Id);

            await _repo.DeleteAsync(item);

            return true;
        }
    }
}
