using Project_API.Data;
using Project_API.Domain.Abstract;
using Project_API.Entities.UserAggregate;
using System.Linq.Expressions;

public interface IUserRepository: IDisposable
{
    void Delete(StronglyTypedId<Guid> id);
    IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "");
    User GetByID(StronglyTypedId<Guid> id);
    void Insert(User entity);
    void Save();
    Task SaveChangesAsync();
    void Update(User entityToUpdate);
}