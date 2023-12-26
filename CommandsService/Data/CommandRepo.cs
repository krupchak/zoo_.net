using System;
using System.Collections.Generic;
using System.Linq;
using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(int animalsId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.AnimalID = animalsId;
            _context.Commands.Add(command);
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

        public Command GetCommand(int animalsId, int commandId)
        {
            return _context.Commands
                .Where(c => c.AnimalID == animalsId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForAnimals(int animalsId)
        {
            return _context.Commands
                .Where(c => c.AnimalID == animalsId)
                .OrderBy(c => c.Animal.Name);
        }

        public bool AnimalsExits(int animalsId)
        {
            return _context.Animals.Any(a => a.Id == animalsId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}