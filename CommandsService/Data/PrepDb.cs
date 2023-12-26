using System;
using System.Collections.Generic;
using CommandsService.Models;
using CommandsService.SyncDataServices.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IAnimalsDataClient>();

                var animals = grpcClient.ReturnAllAnimals();

                SeedData(serviceScope.ServiceProvider.GetService<ICommandRepo>(), animals);
            }
        }
        
        private static void SeedData(ICommandRepo repo, IEnumerable<Animals> animals)
        {
            Console.WriteLine("Seeding new platforms...");

            repo.SaveChanges();
        }
    }
}