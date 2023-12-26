using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/animals/{animalsId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForAnimals(int animalsId)
        {
            Console.WriteLine($"--> Hit GetCommandsForAnimals: {animalsId}");

            if (!_repository.AnimalsExits(animalsId))
            {
                return NotFound();
            }

            var commands = _repository.GetCommandsForAnimals(animalsId);

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{commandId}", Name = "GetCommandsForAnimals")]
        public ActionResult<CommandReadDto> GetCommandsForAnimals(int animalsId, int commandId)
        {
            Console.WriteLine($"--> Hit GetCommandsForAnimals: {animalsId} / {commandId}");

            if (!_repository.AnimalsExits(animalsId))
            {
                return NotFound();
            }

            var command = _repository.GetCommand(animalsId, commandId);

            if(command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> GetCommandsForAnimals(int animalsId, CommandCreateDto commandDto)
        {
             Console.WriteLine($"--> Hit GetCommandsForAnimals: {animalsId}");

            if (!_repository.AnimalsExits(animalsId))
            {
                return NotFound();
            }

            var command = _mapper.Map<Command>(commandDto);

            _repository.CreateCommand(animalsId, command);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandsForAnimals),
                new {animalsId = animalsId, commandId = commandReadDto.Id}, commandReadDto);
        }

    }
}