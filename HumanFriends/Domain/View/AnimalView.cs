using HumanFriends.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HumanFriends.Domain.View
{
    public class AnimalView
    {
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }


        [Display(Name = "День рождения")]
        public DateOnly Birthday { get; set; }

        [Required(ErrorMessage = "Укажите тип животного")]
        [Display(Name = "Тип животного")]

        public int SelectedTypeAnimal { get; set; }
        public List<SelectListItem> TypeAnimalSelectList { get; set; }

        public bool[] SelectedCommandsAnimalByID { get; set; }
        [Display(Name = "Выполняемые команды: ")]
        public List<Command> CommandsAnimalSelect { get; set; }
    }
}
