using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_API.Controllers._Users;
using Project_API.Entities.AnimalAggregate;
using Project_API.Features._Animals;

[TestClass]
public class CreateAnimalControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private CreateAnimalController _createAnimalController;

    [TestInitialize]
    public void Initialize()
    {
        _mediatorMock = new Mock<IMediator>();
        _createAnimalController = new CreateAnimalController();
    }

    [TestMethod]
    public async Task Create_WithValidRequest_ReturnsOkResult()
    {
        var request = new CreateAnimalCommand { Name = "Fluffy", Species = new Species("Dog") , HealthCondition = Animal.HealthCondition.Healthy };
        var expectedResult = new CreateAnimalResult
        {
            Name = "Fluffy",
            Species = new Species("Dog"),
            HealthCondition = Animal.HealthCondition.Healthy,
            Message = "Animal has been succesfully created"
        };
        _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(expectedResult);

        var result = await _createAnimalController.Create(request);


        Assert.IsInstanceOfType(result, typeof(ActionResult<CreateAnimalResult>));
        
        Assert.AreEqual(expectedResult, result);
    }
    [TestCleanup]

    [TestMethod]
    public async Task Create_WithInvalidRequest_ReturnsBadRequestResult()
    {
        var request = new CreateAnimalCommand { Name = "Fluffy", Species = new Species("Dog"), HealthCondition = Animal.HealthCondition.Sick };
        _createAnimalController.ModelState.AddModelError("Name", "The Name field is required.");

        var result = await _createAnimalController.Create(request);

        Assert.IsInstanceOfType(result, typeof(ActionResult<CreateAnimalResult>));
        Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

        var badRequestObjectResult = (BadRequestObjectResult)result.Result;

        Assert.IsInstanceOfType(badRequestObjectResult.Value, typeof(SerializableError));

        var errors = (SerializableError)badRequestObjectResult.Value;

        Assert.IsTrue(errors.ContainsKey("Name"));

        var errorList = (string[])errors["Name"];

        Assert.AreEqual("The Name field is required.", errorList[0]);
    }
}
[TestClass]
public class DeleteAnimalControllerTests
{
    private Mock<IAnimalRepository> _animalRepositoryMock;
    private DeleteAnimalController _controller;

    [TestInitialize]
    public void Initialize()
    {
        _animalRepositoryMock = new Mock<IAnimalRepository>();
        _controller = new DeleteAnimalController();
    }

    [TestMethod]
    public async Task Delete_WithValidId_ReturnsOkResult()
    {
        var animal = new Animal(new Animal_ID(Guid.NewGuid()), "Arnoldzik", new Species("Dog"), Animal.HealthCondition.Healthy);
        _animalRepositoryMock.Setup(repo => repo.GetByID(animal.Animal_UUID)).Returns(animal); 

        var result = await _controller.Delete(animal.Animal_UUID);

        Assert.IsInstanceOfType(result, typeof(OkResult));
        
    }
    [TestCleanup]

    [TestMethod]
    public async Task Delete_WithInvalidId_ReturnsNotFoundResult()
    {
        var animal = new Animal(new Animal_ID(Guid.NewGuid()), "Arnoldzik", new Species("Dog"), Animal.HealthCondition.Healthy);
        _animalRepositoryMock.Setup(repo => repo.GetByID(animal.Animal_UUID)).Returns(animal);

        var result = await _controller.Delete(animal.Animal_UUID);

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
    [TestCleanup]

    [TestMethod]
    public async Task Delete_WithException_ReturnsBadRequestResult()
    {
        var animal = new Animal(new Animal_ID(Guid.NewGuid()), "Arnoldzik", new Species("Dog"), Animal.HealthCondition.Healthy);
        _animalRepositoryMock.Setup(repo => repo.GetByID(animal.Animal_UUID)).Returns(animal);

        var result = await _controller.Delete(animal.Animal_UUID);

        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }
}