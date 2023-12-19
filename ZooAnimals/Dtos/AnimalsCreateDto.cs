using System;
using System.ComponentModel.DataAnnotations;

namespace ZooAnimals.Dtos
{
    public class AnimalsCreateDto
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(30)]
        #nullable enable
        public string? Owner { get; set; }

        [MaxLength(30)]
        [Required]
        #nullable disable
        public string AnimalType { get; set; }
    }
}