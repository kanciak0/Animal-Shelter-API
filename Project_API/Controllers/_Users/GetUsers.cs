using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Project_API.Common.Mappings;
using Project_API.DTO;
using Project_API.Entities.UserAggregate;

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

        public async Task<List<GetUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUsers();
            if (user == null)
            {
                return null;
            }
            var userDtos = user.Select(u => u.MapToDto()).ToList();
            return userDtos;
        }
    }
}
