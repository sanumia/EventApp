using AutoMapper;
using EventsApp.Application.Dtos.Image;
using EventsApp.Application.Interfaces;
using EventsApp.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsApp.Domain.Entities;

namespace EventsApp.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<ImageDto> UploadImageAsync(UploadImageDto uploadImageDto, CancellationToken cancellationToken)
        {
            if (uploadImageDto.File.Length == 0 || uploadImageDto.File == null)
            {
                throw new ArgumentException("File is required");
            }

            var allowedContentTypes = new[] { "image/jpeg", "image/jpg", "image/gif", "image/webp" };
            if (!allowedContentTypes.Contains(uploadImageDto.File.ContentType.ToLower()))
            {
                throw new ArgumentException("Invalid file types");
            }
            const long maxFileSize = 5 * 1024 * 1024;
            if (uploadImageDto.File.Length > maxFileSize)
            {
                throw new ArgumentException("Max file size is 5 MB");
            }

            var image = _mapper.Map<Image>(uploadImageDto);//dto to entity
            image.Id = Guid.NewGuid();

            using(var memoryStream  = new MemoryStream()) //file into byte array
            {
                await uploadImageDto.File.CopyToAsync(memoryStream, cancellationToken);
                image.Data = memoryStream.ToArray();
            }
            var createdImage = await _imageRepository.CreateAsync(image, cancellationToken);
            return _mapper.Map<ImageDto>(createdImage);
        }

        public async Task<ImageDto> GetImageByIdAsync(Guid id,  CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetByIdAsync(id, cancellationToken);
            if(image == null)
            {
                throw new KeyNotFoundException($"Image with {id} is not exist");
            }
            return _mapper.Map<ImageDto>(image);
        }
        public async Task<byte[]> GetImageBytesAsync(Guid id, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetByIdAsync(id, cancellationToken);
            if (image == null)
            {
                throw new KeyNotFoundException($"Image with id {id} was not found");
            }
            return image.Data;
        }

        public async Task DeleteImageAsync(Guid id, CancellationToken cancellationToken)
        {
            await _imageRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<ImageDto> UpdateImageAsync(Guid id,UpdateImageDto updateImageDto ,CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetByIdAsync(id, cancellationToken);
            if (image == null)
            {
                throw new KeyNotFoundException($"Image with id {id} was not found");
            }
            if (updateImageDto.File != null && updateImageDto.File.Length > 0)
            {
                var allowedContentTypes = new[] { "image/jpeg", "image/jpg", "image/gif", "image/webp" };
                if (!allowedContentTypes.Contains(updateImageDto.File.ContentType.ToLower()))
                {
                    throw new ArgumentException("Invalid file types");
                }
                const long maxFileSize = 5 * 1024 * 1024;
                if (updateImageDto.File.Length > maxFileSize)
                {
                    throw new ArgumentException("Max file size is 5 MB");
                }
                using (var memoryStream = new MemoryStream())
                {
                    await updateImageDto.File.CopyToAsync(memoryStream);
                    image.Data = memoryStream.ToArray();
                }
            }
            _mapper.Map(updateImageDto, image);
            var updatedImage = await _imageRepository.UpdateAsync(image, cancellationToken);
            return _mapper.Map<ImageDto>(image);

        }
    }
}
