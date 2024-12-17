using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Request
{
    public class VisitInfirmaryRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int NumberOfVisits { get; set; }
    }
}
