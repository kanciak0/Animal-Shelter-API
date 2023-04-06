using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Infrastructure.Persistence;
using System.Diagnostics;

namespace Project_API.Features.User
{
    public class DeleteUserController : ApiControllerBase
    {

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
    public class DeleteUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly DemoDatabaseContext _dbContext;
        public DeleteUserCommandHandler(DemoDatabaseContext dbcontext) { _dbContext = dbcontext; }
        public Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.UUID == request.Id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                _dbContext.Entry(user).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return Task.FromResult(user.UUID);
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}
