using MediatR;
using Moq;
using Project_API.Controllers._Users;
using Project_API.Entities.AnimalAggregate;
using Project_API.Features._Animals;

[TestClass]
public class CreateAnimalCommandHandlerTests
{
    private Mock<IAnimalRepository> _mockRepository;
    private IRequestHandler<CreateAnimalCommand, CreateAnimalResult> _createAnimalCommandHandler;

    [TestInitialize]
    public void Initialize()
    {
        _mockRepository = new Mock<IAnimalRepository>();
        _createAnimalCommandHandler = new CreateAnimalCommandHandler(_mockRepository.Object);
    }

    [TestMethod]
    public async Task CreateAnimalCommandHandler_InsertsAnimalIntoRepository()
    {

        var command = new CreateAnimalCommand
        {
            Name = "Leo",
            Species = new Species("Lion"),
            HealthCondition = Animal.HealthCondition.Healthy
        };


        var result = await _createAnimalCommandHandler.Handle(command, CancellationToken.None);


        _mockRepository.Verify(r => r.Insert(It.IsAny<Animal>()), Times.Once);
        _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        Assert.AreEqual("Leo has been created", result);
    }
}

[TestClass]
public class DeleteAnimalCommandHandlerTests
{
    private Mock<IAnimalRepository> _mockRepository;
    private IRequestHandler<DeleteAnimalCommand, DeleteAnimalResult> _deleteAnimalCommandHandler;

    [TestInitialize]
    public void Initialize()
    {
        _mockRepository = new Mock<IAnimalRepository>();
        _deleteAnimalCommandHandler = new DeleteAnimalCommandHandler(_mockRepository.Object);
    }


    [TestMethod]
    public async Task DeleteAnimalCommandHandler_DeletesAnimalFromRepository()
    {
        var animalId = new Animal_ID(Guid.NewGuid());
        var deleteCommand = new DeleteAnimalCommand { Id = animalId };

        _mockRepository.Setup(r => r.GetByID(animalId))
        .Returns(Animal.CreateAnimal(animalId, "Migger", new Species("Turtle")));

        var result = await _deleteAnimalCommandHandler.Handle(deleteCommand, CancellationToken.None);

        _mockRepository.Verify(r => r.Delete(animalId), Times.Once);
        _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);

        Assert.AreEqual("User has been deleted", result);
    }
}

