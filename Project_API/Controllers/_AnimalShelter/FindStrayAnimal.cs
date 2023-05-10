using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Domain.Abstract;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;

namespace Project_API.Features._AnimalShelter
{
    public class FindStrayAnimal : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<FindStrayAnimalResult>> FindStrayAnimals(FindStrayAnimalCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class FindStrayAnimalCommand : IRequest<FindStrayAnimalResult>
    {
        public AnimalShelter_ID AnimalShelter_ID { get; set; }
        public Animal_ID Animal_ID { get; set; }
    }
    public class FindStrayAnimalResult
    {
        public AnimalShelter_ID AnimalShelter_id { get; set; }
        public ShelteredAnimal_ID ShelteredAnimal_id { get; set; }
        public string Message { get; set; }
    }
    internal class FindStrayAnimalHandler : IRequestHandler<FindStrayAnimalCommand, FindStrayAnimalResult>
    {
        private readonly IFindStrayAnimalsUoW _findStrayAnimalsUow;
        public FindStrayAnimalHandler(IFindStrayAnimalsUoW findStrayAnimalsUoW )
        {
            _findStrayAnimalsUow = findStrayAnimalsUoW;
        }
        public async Task<FindStrayAnimalResult> Handle(FindStrayAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _findStrayAnimalsUow.DoWork(request);
                return await Task.FromResult(new FindStrayAnimalResult
                {
                    AnimalShelter_id = request.AnimalShelter_ID,
                    ShelteredAnimal_id = new ShelteredAnimal_ID(request.Animal_ID.Value),
                Message = "Animal has been successfully given to shelter"
                });
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}


