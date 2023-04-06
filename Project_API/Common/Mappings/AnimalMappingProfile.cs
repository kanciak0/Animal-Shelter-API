using Project_API.Common.Models;
using Project_API.DTO;
using Project_API.Entities;
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

        public static Animal MapToEntity(this GetAnimalDto animalDto)
        {
            return new Animal
            {
                Animal_UUID = animalDto.Animal_Uuid,
                Name = animalDto.Name,
                Species = animalDto.Species
            };
        }
    }
}

