
namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class Client
    {
        
        private Client() { }
        public Client_ID Client_UUID { get; private set; }
        public string UserName { get; private set; }
        public ClientCredentials Credentials { get; private set; }
        public ClientAddress Address { get; private set; }
        public int Age { get; private set; }

        public Responsibility _Responsibility { get; private set; }
        public class Responsibility : Enumeration
        {
            public static Responsibility Responsible = new Responsibility("Responsible", nameof(Responsible));
            public static Responsibility Irresponsible = new Responsibility("Irresponsible", nameof(Irresponsible));
            public Responsibility(string id, string name) : base(id, name) { }
        }
        public static Client CreateClient(Client_ID client_UUID, string username, ClientCredentials credentials, ClientAddress address, int age)
        {
            return new Client
            {
                Client_UUID = client_UUID,
                UserName = username,
                Credentials = credentials,
                Address = address,
                Age = age
            };
        }
    }
}
