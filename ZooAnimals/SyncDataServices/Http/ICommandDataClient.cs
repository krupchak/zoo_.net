using System.Threading.Tasks;
using ZooAnimals.Dtos;

namespace ZooAnimals.SyncDataClient.Http
{
    public interface ICommandDataClient
    {
        Task SendAnimalsToCommand(AnimalsReadDto animals);
    }
}