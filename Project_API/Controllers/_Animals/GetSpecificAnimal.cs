using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.DTO;
using Project_API.Entities.AnimalAggregate;

public class GetSpecificAnimalController : ApiControllerBase
{
    [HttpGet("{animalId}")]
    public async Task<ActionResult<GetAnimalDto>> GetSpecific([FromQuery] Animal_ID animalId)
    {
        var animal = await Mediator.Send(new GetSpecificAnimalQuery { Animal_ID = animalId });

        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }
}

public class GetSpecificAnimalQuery : IRequest<GetAnimalDto>
{
    public Animal_ID Animal_ID { get; set; }
}

internal class GetSpecificAnimalQueryHandler : IRequestHandler<GetSpecificAnimalQuery, GetAnimalDto>
{
    private readonly IAnimalRepository _animalRepository;

    public GetSpecificAnimalQueryHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<GetAnimalDto> Handle(GetSpecificAnimalQuery request, CancellationToken cancellationToken)
    {
        var animal =  _animalRepository.GetByID(request.Animal_ID);

        if (animal == null)
        {
            return null;
        }

        return await Task.FromResult(animal.MapToDto());
    }
}
