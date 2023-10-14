using Microsoft.EntityFrameworkCore;
using HumanFriends.Domain.Entity;

namespace HumanFriends.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<ApplicabilityAnimal> ApplicabilityAnimal { get; set; }
        public DbSet<ApplicabilityCommand> ApplicabilityCommand { get; set; }
        public DbSet<Command> Command { get; set; }
        public DbSet<TypeAnimal> TypeAnimal { get; set; }




    }
}
