using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DTOs
{
    public class EmployeeDTO
    {
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "Formato de matrícula inválido. O formato correto é CCNNNN (ex. AA1234, AB9876)")]
        public string RegisterNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF inválido. O CPF deve conter exatamente 11 dígitos.")]
        public string CPF { get; set; }
    }
}
