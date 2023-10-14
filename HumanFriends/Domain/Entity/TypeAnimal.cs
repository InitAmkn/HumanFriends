
namespace HumanFriends.Domain.Entity
{
    public class TypeAnimal
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required ApplicabilityAnimal ApplicabilityAnimal { get; set; }
    }
}
