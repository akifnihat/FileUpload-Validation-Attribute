using AutoMapper;
using TaskBack.DTOs;
using TaskBack.Models;

namespace TaskBack.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Slider, SliderReadDto>();
        // For create/update, we'll handle FileUrl via file helper, so ignore mapping from IFormFile
        CreateMap<SliderCreateDto, Slider>()
            .ForMember(d => d.FileUrl, opt => opt.Ignore());
        CreateMap<SliderUpdateDto, Slider>()
            .ForMember(d => d.FileUrl, opt => opt.Ignore());
        CreateMap<Slider, SliderUpdateDto>()
            .ForMember(d => d.Image, opt => opt.Ignore());
    }
}
