using HumanFriends.DAL.Interfaces;
using HumanFriends.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HumanFriends.DAL.Repositories
{
    public class ApplicabilityAnimalRepository : IBaseRepository<ApplicabilityAnimal>
    {
        private readonly ApplicationDbContext db;

        public ApplicabilityAnimalRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(ApplicabilityAnimal entity)
        {
            await db.ApplicabilityAnimal.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(ApplicabilityAnimal entity)
        {
            db.ApplicabilityAnimal.Remove(entity);
            await db.SaveChangesAsync();
        }

        public IQueryable<ApplicabilityAnimal> GetAll()
        {
            return db.ApplicabilityAnimal;
        }

        public async Task<ApplicabilityAnimal> Update(ApplicabilityAnimal entity)
        {
            db.ApplicabilityAnimal.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
