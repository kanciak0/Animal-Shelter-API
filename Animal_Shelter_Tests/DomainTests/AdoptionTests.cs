using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;

[TestClass]
public class AdoptionTests
{
    private AnimalShelter _animalShelter;

    [TestInitialize]
    public void Initialize()
    {
        var animals = new List<ShelteredAnimal>
    {
        new ShelteredAnimal(new ShelteredAnimal_ID(Guid.NewGuid()), "Fluffy", new ShelteredAnimalSpecies("Turtle")),
        new ShelteredAnimal(new ShelteredAnimal_ID(Guid.NewGuid()), "Buddy", new ShelteredAnimalSpecies("Lion")),
        new ShelteredAnimal(new ShelteredAnimal_ID(Guid.NewGuid()), "Max", new ShelteredAnimalSpecies("Toucan"))
    };
        animals[0].SetCondition(ShelteredAnimal.HealthCondition.Healthy);
        animals[0].SetAdoptionStatus(ShelteredAnimal.AdoptionStatus.Adopted);

        animals[1].SetCondition(ShelteredAnimal.HealthCondition.Sick);
        animals[1].SetAdoptionStatus(ShelteredAnimal.AdoptionStatus.NotAdopted);

        animals[2].SetCondition(ShelteredAnimal.HealthCondition.Healthy);
        animals[2].SetAdoptionStatus(ShelteredAnimal.AdoptionStatus.NotAdopted);

        var clients = new List<Client>
    {
        new Client(new Client_ID(Guid.NewGuid()), "Kanciak0",
        new ClientCredentials ("Artur","Madejski"),
        new ClientAddress ("Juszkowo","83-000","Widokowa",9),22),

        new Client(new Client_ID(Guid.NewGuid()), "Nyglet",
        new ClientCredentials ("Mikołaj","Najdżer"),
        new ClientAddress ("Pruszcz Gdański","83-000","Sezamkowa",16),15),

        new Client(new Client_ID(Guid.NewGuid()), "Parowa69",
        new ClientCredentials ("Maciek","Wariacik"),
        new ClientAddress ("Gdańsk","21-37","Magiczna",2),69)
    };
        clients[0].SetResponsibility(Client.Responsibility.Responsible);
        clients[1].SetResponsibility(Client.Responsibility.Irresponsible);
        clients[2].SetResponsibility(Client.Responsibility.Responsible);

        var adoptions = new List<Adoption>();

        _animalShelter = new AnimalShelter(animals, clients, adoptions);

    }

    //TODO: Make these exception throws actually meaningful ^^.
    [TestMethod]
    public void GiveToAdoption_ShouldThrowNotImplementedException_WhenClientIsNull()
    {
        var clientId = _animalShelter.clients.FirstOrDefault()?.Client_UUID;
        var animalId = _animalShelter.animals.FirstOrDefault()?.ShelteredAnimal_UUID;

        Assert.ThrowsException<NotImplementedException>(() => _animalShelter.GiveToAdoption(clientId, animalId));
    }

    [TestMethod]
    public void GiveToAdoption_ShouldThrowNotImplementedException_WhenClientIsUnderage()
    {

        var client = _animalShelter.clients.FirstOrDefault(c => c.Age < 18);
        var clientId = client?.Client_UUID ?? new Client_ID(Guid.NewGuid());
        var animalId = _animalShelter.animals.FirstOrDefault()?.ShelteredAnimal_UUID;

        // Act + Assert
        Assert.ThrowsException<NotImplementedException>(() => _animalShelter.GiveToAdoption(clientId, animalId));
    }

    [TestMethod]
    public void GiveToAdoption_ShouldThrowNotImplementedException_WhenAnimalIsSick()
    {
        var animal = _animalShelter.animals.First(a => a.Condition == ShelteredAnimal.HealthCondition.Sick);
        var clientId = _animalShelter.clients.FirstOrDefault()?.Client_UUID;
        var animalId = animal?.ShelteredAnimal_UUID ?? new ShelteredAnimal_ID(Guid.NewGuid());

        // Act + Assert
        Assert.ThrowsException<NotImplementedException>(() => _animalShelter.GiveToAdoption(clientId, animalId));
    }

    [TestMethod]
    public void GiveToAdoption_ShouldThrowNotImplementedException_WhenAnimalIsAlreadyAdopted()
    {
        var animal = _animalShelter.animals.First(a => a.Status == ShelteredAnimal.AdoptionStatus.Adopted);
        var clientId = _animalShelter.clients.First().Client_UUID;
        var animalId = animal?.ShelteredAnimal_UUID ?? new ShelteredAnimal_ID(Guid.NewGuid());

        Assert.ThrowsException<NotImplementedException>(() => _animalShelter.GiveToAdoption(clientId, animalId));
    }
}
      
