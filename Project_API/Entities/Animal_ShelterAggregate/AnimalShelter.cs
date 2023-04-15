using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_API.Common.Mappings;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.ComponentModel;
using System.Threading;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class AnimalShelter
    {
        ICollection<ShelteredAnimal> animals;
        ICollection<Client> clients;
        Adoption Adoptions;
        private AnimalShelter()
        {
            Adoptions = new Adoption();
        }
        public void Adopt(Client_ID clientid, ShelteredAnimal_ID shelteredanimalid,Client client,ShelteredAnimal shelteredanimal)
        {
            if (clientid == null) { throw new NotImplementedException(); }
            else if (client.Age <= 18 ) { throw new NotImplementedException(); }
            else if (shelteredanimal.Condition== ShelteredAnimal.HealthCondition.Sick) { throw new NotImplementedException(); }
            else if (client._Responsibility == Client.Responsibility.Irresponsible) { throw new NotImplementedException(); }
            else  Adoptions.AddToAdoptions(clientid, shelteredanimalid);
        }
    }
}
