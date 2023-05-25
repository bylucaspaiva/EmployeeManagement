using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Models
{
    public class Company
    {

        //[RegularExpression(@"\d{14}", ErrorMessage = "CNPJ deve ter 14 dígitos")]
        [Key]
        [Required]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "Formato de CNPJ inválido. O formato correto é XX.XXX.XXX/XXXX-XX.")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "O CNPJ deve conter exatamente 18 caracteres.")]
        public string CNPJ { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string TradeName { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
