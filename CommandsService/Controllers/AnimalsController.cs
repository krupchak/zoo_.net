using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using CommandsService.Data;
using CommandsService.Dtos;
using AutoMapper;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private ICommandRepo _repository;
        private IMapper _mapper;

        public AnimalsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Animals from CommandsService");

            var animalsItems = _repository.GetAllAnimals();

            return Ok(_mapper.Map<IEnumerable<AnimalReadDto>>(animalsItems));
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test of from Animals Controller");
        }
    }    
}