using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Controllers._Users
{
    public class CreateAnimalController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Create(CreateAnimalCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateAnimalCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Species { get; set; }
    }
    internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, string>
    {
        private readonly DemoDatabaseContext _dbcontext;
        public CreateAnimalCommandHandler(DemoDatabaseContext dbcontext) { _dbcontext = dbcontext; }
        public Task<string> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var entity = Animal_Entity.Create(request.Name, request.Species);
            _dbcontext.Animals.Add(entity);

            _dbcontext.SaveChanges();
            return Task.FromResult(entity.Name+"has been created");
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