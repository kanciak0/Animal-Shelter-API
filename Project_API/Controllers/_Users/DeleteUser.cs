﻿using Azure.Identity;
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
        public async Task<ActionResult<string>> Delete([FromRoute]User_ID id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return Ok();
        }
    }
    public class DeleteUserCommand : IRequest<string>
    {
        public User_ID Id { get; set; }
    }
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly DemoDatabaseContext _dbcontext;
        public DeleteUserCommandHandler(DemoDatabaseContext dbcontext) { _dbcontext = dbcontext; }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _dbcontext.Users.FirstOrDefault(x => x.User_UUID == request.Id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                _dbcontext.Entry(user).State = EntityState.Deleted;
                _dbcontext.SaveChanges();
                return await Task.FromResult("User has been deleted");
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}