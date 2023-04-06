using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common.Models;
using Project_API.Common;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence;
/*
namespace Project_API.Features._Animals
{
    public class CreateAnimal
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
           
        }
        internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Guid>
        {
            private readonly DemoDatabaseContext _dbContext;
            public CreateAnimalCommandHandler(DemoDatabaseContext dbcontext) { _dbContext = dbcontext; }
            public Task<Guid> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
            {

                var newUser = new UserModel
                    (

                        Guid.NewGuid(),
                        request.UserName,
                        request.FirstName,
                        request.LastName,
                        request.City,
                        request.Country,
                        request.State,
                        request.Animals

                    );
                var entity = new Users
                {
                    UUID = newUser.User_UUID,
                    UserName = newUser.UserName,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    City = newUser.City,
                    Country = newUser.Country,
                    State = newUser.State,
                    Animals = newUser.Animals
                };

                _dbContext.Users.Add(entity);

                _dbContext.SaveChangesAsync(cancellationToken);
                return Task.FromResult(entity.UUID);
            }
        }
    }
}

*/