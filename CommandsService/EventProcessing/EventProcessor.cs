using System;
using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.AnimalsPublished:
                    addAnimals(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch(eventType.Event)
            {
                case "Animals_Published":
                    Console.WriteLine("--> Animals Published Event Detected");
                    return EventType.AnimalsPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addAnimals(string animalsPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();
                
                var animalsPublishedDto = JsonSerializer.Deserialize<AnimalsPublishedDto>(animalsPublishedMessage);

                try
                {
                    Console.WriteLine("--> Animals added!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Animals to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        AnimalsPublished,
        Undetermined
    }
}