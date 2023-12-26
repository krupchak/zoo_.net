using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using ZooAnimals.Data;

namespace ZooAnimals.SyncDataServices.Grpc
{
    public class GrpcAnimalsService : GrpcAnimals.GrpcAnimalsBase
    {
        private readonly IAnimalsRepo _repository;
        private readonly IMapper _mapper;

        public GrpcAnimalsService(IAnimalsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override Task<AnimalsResponse> GetAllAnimals(GetAllRequest request, ServerCallContext context)
        {
            var response = new AnimalsResponse();
            var animals = _repository.GetAllAnimals();

            foreach(var anim in animals)
            {
                response.Animal.Add(_mapper.Map<GrpcAnimalsModel>(anim));
            }

            return Task.FromResult(response);
        }
    }
}