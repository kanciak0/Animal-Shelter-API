using Project_API.Common.Models;
using Project_API.DTO;
using Project_API.Entities;
using Project_API.Features.User;

namespace Project_API.Common.Mappings
{ 

    static public class AnimalMappingProfile
    {
        public static GetAnimalDto MapToDto(this Animal_entity animal)
        {
            return new GetAnimalDto
            {
                Animal_Uuid = animal.Animal_UUID,
                Name = animal.Name,
                Species = animal.Species
            };
        }

        public static Animal_entity MapToEntity(this GetAnimalDto animalDto)
        {
            return new Animal_entity
            {
                Animal_UUID = animalDto.Animal_Uuid,
                Name = animalDto.Name,
                Species = animalDto.Species
            };
        }
    }
}

