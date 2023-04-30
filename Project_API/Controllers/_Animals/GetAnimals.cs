using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.DTO;

namespace Project_API.Features._Animals
{
    public class GetAnimalsController : ApiControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<List<GetAnimalDto>>> Get()
        {
            var animallist = await Mediator.Send(new GetAnimalQuery());
            return animallist;
        }
    }

    public class GetAnimalQuery : IRequest<List<GetAnimalDto>>
    {

    }

    internal class GetAnimalQueryHandler : IRequestHandler<GetAnimalQuery, List<GetAnimalDto>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAnimalQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public  async Task<List<GetAnimalDto>> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
        {
            var animals = await Task.Run(() => _animalRepository.Get());
            if (animals == null)
            {
                return null;
            }
            var animaldtos = animals.Select(u => u.MapToDto()).ToList();
            return animaldtos;
        }
    }
}
