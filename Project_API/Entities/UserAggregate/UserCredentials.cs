namespace Project_API.Entities.UserAggregate
{
    public class UserCredentials : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private UserCredentials() { }
        public UserCredentials(string firstname, string lastname)
        {
            firstname = FirstName;
            lastname = LastName;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;

        }
    }
}
