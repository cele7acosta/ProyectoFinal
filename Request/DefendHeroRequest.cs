using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Request
{
    public class DefendHeroRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
