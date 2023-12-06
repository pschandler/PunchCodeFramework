﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery
{
    public class DeleteGalleryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
