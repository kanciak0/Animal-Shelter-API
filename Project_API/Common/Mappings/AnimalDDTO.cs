using Project_API.DTO;
using Project_API.Entities.AnimalAggregate;
namespace Project_API.Common.Mappings;
public static class AnimalExtensions
{
    public static GetAnimalDto MapToDto(this Animal_ID animalId)
    {
        return new GetAnimalDto
        {
            Animal_Uuid = animalId
        };
    }
    public static GetAnimalDto MapAnimalConditionToDto(HealthCondition condition)
    {
        return new GetAnimalDto
        {
            Condition = condition.ToString()
        };
    }
}