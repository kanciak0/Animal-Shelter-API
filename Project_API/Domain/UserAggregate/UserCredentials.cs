namespace Project_API.Entities.UserAggregate
{
    public class UserCredentials : ValueObject
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        private UserCredentials() { }
        public UserCredentials(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;

        }
    }
}
