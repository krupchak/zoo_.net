using System;
using System.Collections.Generic;
using System.Linq;
using ZooAnimals.Models;

namespace ZooAnimals.Data
{
    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly AppDbContext _context;

        public AnimalsRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAnimals(Animals animals)
        {
            if(animals == null)
            {
                throw new ArgumentNullException(nameof(animals));
            }

            _context.Animals.Add(animals);
        }

        public IEnumerable<Animals> GetAllAnimals()
        {
            return _context.Animals.ToList();
        }

        public Animals GetAnimalsById(int id)
        {
            return _context.Animals.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}