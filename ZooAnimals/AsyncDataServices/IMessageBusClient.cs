using ZooAnimals.Dtos;

namespace ZooAnimals.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewAnimals(AnimalsPublishedDto animalsPublishedDto);
    }
}