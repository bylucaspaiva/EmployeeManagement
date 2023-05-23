using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "Matricula deve seguir o formato CCNNNN")]
        public string RegisterNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? TerminationDate { get; set; }
        public string? CompanyCNPJ { get; set; }
        public Company? Company { get; set; }
        public ICollection<JobHistory> JobHistory { get; set; } = new List<JobHistory>();

        public Employee(string registerNumber, string name, string cPF)
        {
            RegisterNumber = registerNumber;
            Name = name;
            CPF = cPF;
        }

        public bool IsValid()
        {
            return TerminationDate == null || TerminationDate > StartDate;
        }
    }
}
