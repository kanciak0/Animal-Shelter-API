using Microsoft.EntityFrameworkCore;

public class UserRepositoryFactory : IUserRepositoryFactory
{
    private readonly DbContext _context;

    public UserRepositoryFactory(DbContext context)
    {
        _context = context;
    }

    public IUserRepository CreateUserRepository()
    {
        return new UserRepository(_context);
    }
}
