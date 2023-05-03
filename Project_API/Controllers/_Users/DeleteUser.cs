using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Entities.UserAggregate;

namespace Project_API.Features.User
{
    public class DeleteUserController : ApiControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserResult>> Delete( User_ID id)
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
    public class DeleteUserCommand : IRequest<DeleteUserResult>
    {
        public User_ID Id { get; set; }
    }
    public class DeleteUserResult
    {
        public User_ID Id { get; set; }
        public string Message { get; set; }
    }
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResult>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<DeleteUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepository.GetByID(request.Id.ToGuid());
                _userRepository.Delete(user.User_UUID.ToGuid());//Check after
                await _userRepository.SaveChangesAsync();
                _userRepository.Dispose();

                return new DeleteUserResult
                {
                    Id = request.Id,
                    Message = "User has been deleted"
                };
            }
            catch (Exception)
            {
                throw new Exception("An error has occurred");
            }
        }
    }
}

