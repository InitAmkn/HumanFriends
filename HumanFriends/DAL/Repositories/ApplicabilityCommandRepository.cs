using HumanFriends.DAL.Interfaces;
using HumanFriends.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HumanFriends.DAL.Repositories
{
    public class ApplicabilityCommandRepository : IBaseRepository<ApplicabilityCommand>
    {
        private readonly ApplicationDbContext db;

        public ApplicabilityCommandRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(ApplicabilityCommand entity)
        {
            await db.ApplicabilityCommand.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(ApplicabilityCommand entity)
        {
            db.ApplicabilityCommand.Remove(entity);
            await db.SaveChangesAsync();
        }

        public IQueryable<ApplicabilityCommand> GetAll()
        {
            return db.ApplicabilityCommand;
        }

        public async Task<ApplicabilityCommand> Update(ApplicabilityCommand entity)
        {
            db.ApplicabilityCommand.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
