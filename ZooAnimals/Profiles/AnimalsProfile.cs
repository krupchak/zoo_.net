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
        }
    }
 }