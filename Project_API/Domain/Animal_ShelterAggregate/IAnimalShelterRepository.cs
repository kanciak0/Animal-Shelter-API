﻿using Project_API.Entities.Animal_ShelterAggregate;
using System.Linq.Expressions;

namespace Project_API.Domain.Animal_ShelterAggregate
{
    public interface IAnimalShelterRepository: IDisposable
    {
        void Delete(int id);
        IEnumerable<AnimalShelter> Get(Expression<Func<AnimalShelter, bool>> filter = null, Func<IQueryable<AnimalShelter>, IOrderedQueryable<AnimalShelter>> orderBy = null, string includeProperties = "");
        AnimalShelter GetByID(int id);
        void Insert(AnimalShelter entity);
        void Save();
        Task SaveChangesAsync();
        void Update(AnimalShelter entityToUpdate);
    }
}