namespace Project_API.Entities.UserAggregate
{
    using Microsoft.EntityFrameworkCore;
    using Project_API.Infrastructure.Persistence;
    public class UserRepository : IUserRepository, IDisposable
    {
        private DemoDatabaseContext _dbcontext;
        public UserRepository(DemoDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _dbcontext.Users.ToList();
        }
        public User GetUserByID(User_ID user_id)
        {
            return _dbcontext.Users.FirstOrDefault(user => user.User_UUID == user_id);
        }
        public void InsertUser(User user)
        {
            _dbcontext.Users.Add(user);
        }
        public void DeleteUser(User_ID user_id)
        {
            User user = _dbcontext.Users.FirstOrDefault(user => user.User_UUID == user_id);
            _dbcontext.Users.Remove(user);
        }
        public void UpdateUser(User user)
        {
            _dbcontext.Entry(user).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
