﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "Formato de matrícula inválido. O formato correto é CCNNNN (ex. AA1234, AB9876)")]
        public string RegisterNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF inválido. O CPF deve conter exatamente 11 dígitos.")]
        public string CPF { get; set; }
        public string? CompanyCNPJ { get; set; }
        public Company? Company { get; set; }
        public ICollection<JobTitle> JobHistory { get; set; } = new List<JobTitle>();
        public bool IsActive { get; set; }
    }
}
