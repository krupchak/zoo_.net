using System;

namespace ZooAnimals.Dtos 
{
    public class AnimalsReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        #nullable enable
        public string? Owner { get; set; }

        #nullable disable
        public string AnimalType { get; set; }
    }
}