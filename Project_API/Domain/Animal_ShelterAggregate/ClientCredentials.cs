namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class ClientCredentials: ValueObject
    {
        public string FirstName{ get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public ClientCredentials(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        private ClientCredentials() { }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
