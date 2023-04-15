namespace Project_API.Entities.UserAggregate
{
    public interface IUserRepository :IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(User_ID user_id);
        void InsertUser(User user);
        void DeleteUser(User_ID user_id);
        void UpdateUser(User user);
        void Save();
    }
}
