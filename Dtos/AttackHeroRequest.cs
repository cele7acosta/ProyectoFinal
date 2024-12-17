using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Dtos
{
    public class AttackHeroRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
