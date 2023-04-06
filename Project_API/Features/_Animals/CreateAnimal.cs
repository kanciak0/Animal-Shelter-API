using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.Common.Models;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Controllers._Users
{
    public class CreateAnimalController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAnimalCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateAnimalCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Species { get; set; }
    }
    internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Guid>
    {
        private readonly DemoDatabaseContext _dbcontext;
        public CreateAnimalCommandHandler(DemoDatabaseContext dbcontext) { _dbcontext = dbcontext; }
        public Task<Guid> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var entity = new Animal
            {
                Animal_UUID = Guid.NewGuid(),
                Name = request.Name,
                Species = request.Species,
                User = null
            };
            _dbcontext.Animals.Add(entity);

            _dbcontext.SaveChanges();
            return Task.FromResult(entity.Animal_UUID);
        }
    }
    public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
    {
        private readonly DemoDatabaseContext _dbcontext;
        public CreateAnimalCommandValidator(DemoDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;

            RuleFor(x => x.Name)
                   .MaximumLength(50)
                   .NotEmpty();
            RuleFor(x => x.Species)
                    .MaximumLength(50)
                    .NotEmpty();
        }
    }
}