using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.Diagnostics;
using Project_API.Common.Mappings;
using Azure.Core;
using static Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimal;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities;
using Microsoft.Extensions.Options;

namespace Project_API.Features._AnimalShelter
{
    public class AdoptController : ApiControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<AdoptResult>> Adoptions(AdoptCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class AdoptCommand : IRequest<AdoptResult>
    {
        public User_ID User_Id { get; set; }
        public ShelteredAnimal_ID ShelteredAnimal_ID { get; set; }
        public AnimalShelter_ID AnimalShelter_ID { get;set; }
    }
    public class AdoptResult
    {
        public User_ID User_Id { get; set; }
        public ShelteredAnimal_ID ShelteredAnimal_ID { get; set; }
        public AnimalShelter_ID AnimalShelter_ID { get; set; }
        public string Message { get; set; }
    }
    internal class AdoptCommandHandler : IRequestHandler<AdoptCommand, AdoptResult>
    {
        private readonly IAdoptionUoW _adoptionUoW;
        public AdoptCommandHandler(IAdoptionUoW adoptionuow)
        {
            _adoptionUoW = adoptionuow;
        }
        public async Task<AdoptResult> Handle(AdoptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _adoptionUoW.DoWork(request);

                return await Task.FromResult(new AdoptResult
                {
                    User_Id = request.User_Id,
                    ShelteredAnimal_ID = request.ShelteredAnimal_ID,
                    AnimalShelter_ID = request.AnimalShelter_ID,
                    Message = "Adoption has been succesfully made"
                });
            }

            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}


