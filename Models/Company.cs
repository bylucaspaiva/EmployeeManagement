using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Models
{
    public class Company
    {


        [Key]
        [Required]
        [RegularExpression(@"\d{14}", ErrorMessage = "CNPJ deve ter 14 dígitos (apenas números)")]
        public string CNPJ { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string TradeName { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
