using ZooAnimals.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace ZooAnimals.Data
{
    public static class PrepDb 
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeepData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeepData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            
            if(!context.Animals.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Animals.AddRange(
                    new Animals() {Name="Brown bear", BirthDate=new DateTime(2017, 07, 17), Owner="Gergana Mancheva", AnimalType="Mammals"},
                    new Animals() {Name="Chimpanzee", BirthDate=new DateTime(2010, 01, 21), Owner="Milena Dragomirova", AnimalType="Mammals"},
                    new Animals() {Name="Cichlid", BirthDate=new DateTime(2021, 01, 21), Owner="Stamat Kostov", AnimalType="Fish"},
                    new Animals() {Name="Ostrich", BirthDate=new DateTime(2016, 05, 02), Owner="Kaloqn Stoqnov", AnimalType="Birds"},
                    new Animals() {Name="Anaconda", BirthDate=new DateTime(2016, 07, 13), Owner="Kamelia Yancheva", AnimalType="Reptiles"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
     }
}