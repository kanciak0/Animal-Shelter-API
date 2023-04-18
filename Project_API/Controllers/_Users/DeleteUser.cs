using Azure.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.Diagnostics;

namespace Project_API.Features.User
{
    public class DeleteUserController : ApiControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete([FromRoute] User_ID id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new DeleteUserCommand { Id = id };
            await Mediator.Send(command);

            return Ok();
        }
    }
    public class DeleteUserCommand : IRequest<string>
    {
        public User_ID Id { get; set; }
    }
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
     
        public DeleteUserCommandHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository; 
        }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _userRepository.DeleteUser(request.Id);//Check after
                _userRepository.SaveChangesAsync();
                return await Task.FromResult("User has been deleted");
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}
