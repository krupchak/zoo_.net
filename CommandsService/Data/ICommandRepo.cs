using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        IEnumerable<Animals> GetAllAnimals();
        void CreateAnimals(Animals animals);
        bool AnimalsExits(int animalsId);

        IEnumerable<Command> GetCommandsForAnimals(int animalsId);
        Command GetCommand(int animalsId, int commandId);
        void CreateCommand(int animalsId, Command command);
    }
}