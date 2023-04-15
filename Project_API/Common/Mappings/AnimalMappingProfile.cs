using Project_API.DTO;
using Project_API.Entities.AnimalAggregate;
using Project_API.Features.User;

namespace Project_API.Common.Mappings
{

    static public class AnimalMappingProfile
    {
        public static GetAnimalDto MapToDto(this Animal animal)
        {
            return new GetAnimalDto
            {
                Animal_Uuid = animal.Animal_UUID,
                Name = animal.Name,
                Species = animal.Species
            };
        }
    }
}

