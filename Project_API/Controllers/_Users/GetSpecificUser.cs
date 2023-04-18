using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.DTO;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;

public class GetSpecificUserController : ApiControllerBase
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<GetUserDto>> GetSpecific([FromQuery]User_ID userId)
    {
        var user = await Mediator.Send(new GetSpecificUserQuery { UserId = userId });

        if (user == null)
        {
            return NotFound();
        }
        return user;
    }
}

public class GetSpecificUserQuery : IRequest<GetUserDto>
{
    public User_ID UserId { get; set; }
}

internal class GetSpecificUserQueryHandler : IRequestHandler<GetSpecificUserQuery, GetUserDto>
{
    private readonly IUserRepository _userRepository;

    public GetSpecificUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserDto> Handle(GetSpecificUserQuery request, CancellationToken cancellationToken)
    {
        var user =  _userRepository.GetUserByID(request.UserId);

        if (user == null)
        {
            return null;
        }

        return user.MapToDto();
    }

}
