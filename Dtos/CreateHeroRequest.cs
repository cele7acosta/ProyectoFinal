using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Dtos
{
    public class CreateHeroRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
