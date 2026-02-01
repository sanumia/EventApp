using AutoMapper;
using EventsApp.Application.Dtos.Image;
using EventsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EventsApp.Application.Mappings
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {

            CreateMap<Image, ImageDto>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => $"/api/images/{src.Id}/file"))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName ?? "image.jpg")) // !=0 -> src.FileName or ==0 dest.FileName = image.jpeg
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType ?? "image/jpeg"));

            CreateMap<UploadImageDto, Image>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.File.FileName))
                    .ForMember(dest => dest.ContentType,
                        opt => opt.MapFrom(src => src.File.ContentType))
                    .ForMember(dest => dest.Size,
                        opt => opt.MapFrom(src => src.File.Length))
                    .ForMember(dest => dest.Data, opt => opt.Ignore()); 


            CreateMap<UpdateImageDto, Image>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.FileName,
                        opt => opt.MapFrom((src, dest) =>
                            src.File != null ? src.File.FileName : dest.FileName))
                    .ForMember(dest => dest.ContentType,
                        opt => opt.MapFrom((src, dest) =>
                            src.File != null ? src.File.ContentType : dest.ContentType))
                    .ForMember(dest => dest.Size,
                        opt => opt.MapFrom((src, dest) =>
                            src.File != null ? src.File.Length : dest.Size))
                    .ForMember(dest => dest.Data, opt => opt.Ignore()) 
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                        srcMember != null)); 
        }
    }
}
