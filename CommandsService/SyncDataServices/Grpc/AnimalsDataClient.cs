using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Models;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using ZooAnimals;

namespace CommandsService.SyncDataServices.Grpc
{
    public class AnimalsDataClient : IAnimalsDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AnimalsDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<Animals> ReturnAllAnimals()
        {
            Console.WriteLine($"--> Calling GRPC Service {_configuration["GrpcAnimals"]}");
            var channel = GrpcChannel.ForAddress(_configuration["GrpcAnimals"]);
            var client = new GrpcAnimals.GrpcAnimalsClient(channel);
            var request = new GetAllRequest();

            try
            {
                var reply = client.GetAllAnimals(request);
                return _mapper.Map<IEnumerable<Animals>>(reply.Animal);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Couldnot call GRPC Server {ex.Message}");
                return null;
            }
        }
    }
}