using System.ComponentModel.DataAnnotations;

namespace HumanFriends.Domain.Entity
{
    public class Animal
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Имя")]
        public required string Name { get; set; }


        [Display(Name = "День рождения")]
        public DateOnly Birthday { get; set; }

        [Required(ErrorMessage = "Укажите тип животного")]
        [Display(Name = "Тип животного")]
        public TypeAnimal TypeAnimal { get; set; }
    }
}
