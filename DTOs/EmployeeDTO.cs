using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DTOs
{
    public class EmployeeDTO
    {
        public string RegisterNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
