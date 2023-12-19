using ZooAnimals.Models;
using System.Collections.Generic;

namespace ZooAnimals.Data
{
    public interface IAnimalsRepo
    {
        bool SaveChanges();

        IEnumerable<Animals> GetAllAnimals();
        Animals GetAnimalsById(int id);
        void CreateAnimals(Animals animals);
    }
}