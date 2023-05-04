using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Project_API.Domain;
using System.Text.Json.Serialization;
using Project_API.Domain.Abstract;
using Project_API.Entities.UserAggregate;
using Project_API.Migrations;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class Client
    {

        private Client() { }

        [JsonConverter(typeof(StronglyTypedIdJsonConverter<Client_ID>))]
        public Client_ID Client_UUID { get; private set; }
        public string UserName { get; private set; }
        public ClientCredentials Credentials { get; private set; }
        public ClientAddress Address { get; private set; }
        public int Age { get; private set; }
       
        public Responsibility _Responsibility { get; private set; }

        [NotMapped]
        public AnimalShelter AnimalShelter { get; }

        [NotMapped]
        public AnimalShelter_ID animal_shelter_Id { get; }
        public enum Responsibility
        {
            Responsible,
            Irresponsible
        }
        public Client(Client_ID client_UUID, string username, ClientCredentials credentials, ClientAddress address, int age)
        {
            Client_UUID = client_UUID;
            UserName = username;
            Credentials = credentials;
            Address = address;
            Age = age;
        }
        public void SetResponsibility(Responsibility responsibility)
        {
            _Responsibility = responsibility;
        }
        /*      public class Responsibility : Enumeration
             {
                 public static Responsibility Responsible = new Responsibility("Responsible", nameof(Responsible));
                 public static Responsibility Irresponsible = new Responsibility("Irresponsible", nameof(Irresponsible));
                 public Responsibility(string id, string name) : base(id, name) { }
             }*/
    }
}

