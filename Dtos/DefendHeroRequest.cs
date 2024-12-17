using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Dtos
{
    public class DefendHeroRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
