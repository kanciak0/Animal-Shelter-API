using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.DTO;
using Project_API.Entities;
using Project_API.Features.User;
using Project_API.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetSpecificUserController : ApiControllerBase
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<GetUserDto>> GetSpecific([FromRoute] Guid userId)
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
    public Guid UserId { get; set; }
}

internal class GetSpecificUserQueryHandler : IRequestHandler<GetSpecificUserQuery, GetUserDto>
{
    private readonly DemoDatabaseContext _dbContext;

    public GetSpecificUserQueryHandler(DemoDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetUserDto> Handle(GetSpecificUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
                .Include(u => u.Animals)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UUID == request.UserId, cancellationToken);

        return user.MapToDto();
    }
}
