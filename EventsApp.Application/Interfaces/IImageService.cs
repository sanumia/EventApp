using EventsApp.Application.Dtos.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application.Interfaces
{
    public interface IImageService
    {
        Task<ImageDto> UploadImageAsync(UploadImageDto uploadImageDto, CancellationToken cancellationToken=default);
        Task<ImageDto> GetImageByIdAsync(Guid id, CancellationToken cancellationToken=default);
        Task<byte[]> GetImageBytesAsync(Guid id, CancellationToken cancellationToken = default);
        Task DeleteImageAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ImageDto> UpdateImageAsync(Guid id, UpdateImageDto updateImageDto, CancellationToken cancellationToken=default);
    }
}
