using HumanFriends.DAL.Interfaces;
using HumanFriends.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HumanFriends.DAL.Repositories
{
    public class AnimalRepository : IBaseRepository<Animal>
    {
        private readonly ApplicationDbContext db;

        public AnimalRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(Animal entity)
        {
            await db.Animal.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Animal entity)
        {
            db.Animal.Remove(entity);
            await db.SaveChangesAsync();
        }

        public IQueryable<Animal> GetAll()
        {
            return db.Animal;
        }

        public async Task<Animal> Update(Animal entity)
        {
            db.Animal.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
