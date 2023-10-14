using HumanFriends.DAL.Interfaces;
using HumanFriends.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HumanFriends.DAL.Repositories
{
    public class TypeAnimalRepository : IBaseRepository<TypeAnimal>
    {
        private readonly ApplicationDbContext db;

        public TypeAnimalRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(TypeAnimal entity)
        {
            await db.TypeAnimal.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(TypeAnimal entity)
        {
            db.TypeAnimal.Remove(entity);
            await db.SaveChangesAsync();
        }

        public IQueryable<TypeAnimal> GetAll()
        {
            return db.TypeAnimal;
        }

        public async Task<TypeAnimal> Update(TypeAnimal entity)
        {
            db.TypeAnimal.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
