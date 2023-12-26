using AutoMapper;
using CommandsService.Dtos;
using CommandsService.Models;
using ZooAnimals;

namespace CommandsService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Animals, AnimalReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<AnimalsPublishedDto, Animals>();
            CreateMap<GrpcAnimalsModel, Animals>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Commands, opt => opt.Ignore());
        }
    }
}