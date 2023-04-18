/*
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System;
using System.Net;

namespace Project_API.Features.User
{
    public class UpdateUserController : ApiControllerBase
    {
        [HttpPut("{uuid}")]
        public async Task<ActionResult<string>> Update([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }

    public class UpdateUserCommand : IRequest<string>
    {
        public User_ID Uuid { get; set; }
        public string UserName { get; set; }

    }

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.User_UUID.Equals(request.Uuid));

                if (user == null)
                {
                    throw new Exception("User not found");
                }
                var userentity = Entities.UserAggregate.User.Update(request.Uuid, request.UserName);
                _dbcontext.Entry(user).State = EntityState.Detached;
                _dbcontext.Entry(userentity).State = EntityState.Modified;
                await _dbcontext.SaveChangesAsync(cancellationToken);

                return "Username has been updated";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            var user = await _userRepository.GetUserByID(request.Uuid);
            if (user == null)
            {
                throw new Exception("User not found");
            }

        }
    }
    
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly DemoDatabaseContext _dbcontext;
        public UpdateUserCommandValidator(DemoDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbcontext.Users.Load();
            RuleFor(x => x.UserName)
                .MaximumLength(200)
                .NotEmpty()
                .MustAsync(BeUniqueUsername);
            RuleFor(x => x.Uuid)
                .NotEmpty()
                .MustAsync(BeValidUuid);
        }
        private Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            return _dbcontext.Users
               
                .AllAsync(u => u.UserName != username, cancellationToken);
        }
        private Task<bool> BeValidUuid(User_ID uuid, CancellationToken cancellationToken)
        {
            return Task.FromResult(uuid != null && uuid.Value != Guid.Empty);
        }
    }
}

*/