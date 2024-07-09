using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Description { get; set; }
    }
}
