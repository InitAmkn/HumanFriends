using HumanFriends.DAL.Interfaces;
using HumanFriends.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HumanFriends.DAL.Repositories
{
    public class CommandRepository : IBaseRepository<Command>
    {
        private readonly ApplicationDbContext db;

        public CommandRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(Command entity)
        {
            await db.Command.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Command entity)
        {
            db.Command.Remove(entity);
            await db.SaveChangesAsync();
        }

        public IQueryable<Command> GetAll()
        {
            return db.Command;
        }

        public async Task<Command> Update(Command entity)
        {
            db.Command.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
