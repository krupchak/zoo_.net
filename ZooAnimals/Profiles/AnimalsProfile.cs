using AutoMapper;
using ZooAnimals.Models;
using ZooAnimals.Dtos;

 namespace ZooAnimals.Profiles
 {
    public class AnimalsProfile : Profile
    {
        public AnimalsProfile()
        {
            // Source -> Target
            CreateMap<Animals, AnimalsReadDto>();
            CreateMap<AnimalsCreateDto, Animals>();
            CreateMap<AnimalsReadDto, AnimalsPublishedDto>();
            CreateMap<Animals, GrpcAnimalsModel>()
                .ForMember(dest => dest.AnimalsId, opt => opt.MapFrom(src =>src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>src.Name));
        }
    }
 }