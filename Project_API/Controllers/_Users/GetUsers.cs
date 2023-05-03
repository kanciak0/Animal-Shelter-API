using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.DTO;

namespace Project_API.Features.User
{
    public class GetUserController : ApiControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<List<GetUserDto>>> Get()
        {
            var userlist = await Mediator.Send(new GetUserQuery());
            return userlist;
        }
    }

    public class GetUserQuery : IRequest<List<GetUserDto>>
    {

    }

    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUserDto>?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await Task.Run(() => _userRepository.Get());
            if (users == null)
            {
                return null;
            }
            var userDtos = users.Select(u => u.MapToDto()).ToList();
            return userDtos;
        }
    }
}
