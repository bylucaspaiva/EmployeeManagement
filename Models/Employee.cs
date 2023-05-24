using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "Matricula deve seguir o formato CCNNNN")]
        public string RegisterNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CPF { get; set; }
        public string? CompanyCNPJ { get; set; }
        public Company? Company { get; set; }
        public ICollection<JobTitle> JobHistory { get; set; } = new List<JobTitle>();
    }
}
