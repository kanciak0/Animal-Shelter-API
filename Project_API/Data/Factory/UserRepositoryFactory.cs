using Microsoft.EntityFrameworkCore;
using Project_API.Infrastructure.Persistence;

public class UserRepositoryFactory : IUserRepositoryFactory
{
    private readonly DatabaseContext _context;

    public UserRepositoryFactory(DatabaseContext context)
    {
        _context = context;
    }

    public IUserRepository CreateUserRepository()
    {
        return new UserRepository(_context);
    }
}
