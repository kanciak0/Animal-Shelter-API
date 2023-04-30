using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project_API.DTO;
using Project_API.Entities.AnimalAggregate;
using Project_API.Features._Animals;
using System.Linq.Expressions;
using System.Reflection;

[TestClass]
public class AnimalQueryHandlersTests
{
    private Mock<IAnimalRepository> _mockRepository;
    private IRequestHandler<GetAnimalQuery, List<GetAnimalDto>> _getAnimalsHandler;
    private IRequestHandler<GetSpecificAnimalQuery, GetAnimalDto> _getSpecificAnimalHandler;

    [TestInitialize]
    public void Initialize()
    {
        _mockRepository = new Mock<IAnimalRepository>();

        _getAnimalsHandler = new GetAnimalQueryHandler(_mockRepository.Object);
        _getSpecificAnimalHandler = new GetSpecificAnimalQueryHandler(_mockRepository.Object);
    }

    [TestMethod]
    public async Task GetAnimalsQueryHandler_ReturnsAnimals()
    {
        var animals = new List<Animal>
        {
            Animal.CreateAnimal(new Animal_ID(Guid.NewGuid()),"Bobby", new Species("Lion")),
            Animal.CreateAnimal(new Animal_ID(Guid.NewGuid()),"Leon", new Species("Toucan")), 
            Animal.CreateAnimal(new Animal_ID(Guid.NewGuid()),"Migger", new Species("Turtle"))
        };

        _mockRepository.Setup(r => r.Get
            (It.IsAny<Expression<Func<Animal, bool>>>(),
            It.IsAny<Func<IQueryable<Animal>,
            IOrderedQueryable<Animal>>>(), ""))
            .Returns(animals);


        var query = new GetAnimalQuery();

        var result = await _getAnimalsHandler.Handle(query, CancellationToken.None);

        Assert.IsNotNull(result);
        Assert.AreEqual(animals.Count, result.Count);
        Assert.AreEqual(animals[0].Name, result[0].Name);
        Assert.AreEqual(animals[0].Species._Species, result[0].Species._Species);
    }

    [TestMethod]
    public async Task GetSpecificAnimalQueryHandler_ReturnsAnimal()
    {
        var animalId = new Animal_ID(Guid.NewGuid());
        var animal = Animal.CreateAnimal(animalId, "Ligger" , new Species("Turtle"));

        _mockRepository.Setup(r => r.GetByID(animalId.ToGuid())).Returns(animal);

        var query = new GetSpecificAnimalQuery { Animal_ID = animalId };

        var result = await _getSpecificAnimalHandler.Handle(query, CancellationToken.None);

        Assert.IsNotNull(result);
        Assert.AreEqual(animal.Name, result.Name);
        Assert.AreEqual(animal.Species._Species, result.Species._Species);
    }
}
