namespace HumanFriends.Domain.Entity
{
    public class ApplicabilityCommand
    {
        public int ID { get; set; }
        public Animal? Animal { get; set; }
        public Command? Command { get; set; }
    }
}
