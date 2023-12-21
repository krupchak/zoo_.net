using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ZooAnimals.Data;
using ZooAnimals.Dtos;
using ZooAnimals.Models;
using System.Collections.Generic;
using System;
using ZooAnimals.SyncDataClient.Http;
using System.Threading.Tasks;

namespace ZooAnimals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public AnimalsController(
            IAnimalsRepo repository, 
            IMapper mapper, 
            ICommandDataClient commandDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalsReadDto>> GetAnimals()
        {
            Console.WriteLine("--> Getting Animals...");

            var animalItem = _repository.GetAllAnimals();

            return Ok(_mapper.Map<IEnumerable<AnimalsReadDto>>(animalItem));
        }

        [HttpGet("{id}", Name = "GetAnimalById")]
        public ActionResult<AnimalsReadDto> GetAnimalById(int id)
        {
            var animalItem = _repository.GetAnimalsById(id);
            if (animalItem != null) 
            {
                return Ok(_mapper.Map<AnimalsReadDto>(animalItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AnimalsReadDto>> CreateAnimal(AnimalsCreateDto animalsCreateDto)
        {
            var animalModel = _mapper.Map<Animals>(animalsCreateDto);
            _repository.CreateAnimals(animalModel);
            _repository.SaveChanges();

            var animalReadDto = _mapper.Map<AnimalsReadDto>(animalModel);

            try
            {
                await _commandDataClient.SendAnimalsToCommand(animalReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetAnimalById), new {Id = animalReadDto.Id}, animalReadDto);
        }
    }
}