using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Request
{
    public class AttackHeroRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
