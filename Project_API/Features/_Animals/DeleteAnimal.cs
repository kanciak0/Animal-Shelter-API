﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence;
using System.Diagnostics;

namespace Project_API.Features.User
{
    public class DeleteAnimalController : ApiControllerBase
    {

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Animal_ID id)
        {
            await Mediator.Send(new DeleteAnimalCommand { Id = id });

            return NoContent();
        }
    }
    public class DeleteAnimalCommand : IRequest<Animal_ID>
    {
        public Animal_ID Id { get; set; }
    }
    internal class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, Animal_ID>
    {
        private readonly DemoDatabaseContext _dbcontext;
        public DeleteAnimalCommandHandler(DemoDatabaseContext dbcontext) { _dbcontext = dbcontext; }
        public Task<Animal_ID> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animal = _dbcontext.Animals.FirstOrDefault(x => x.Animal_UUID == request.Id)
                ?? throw new Exception("User not found");
                _dbcontext.Entry(animal).State = EntityState.Deleted;
                _dbcontext.SaveChanges();
                return Task.FromResult(animal.Animal_UUID);
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}
