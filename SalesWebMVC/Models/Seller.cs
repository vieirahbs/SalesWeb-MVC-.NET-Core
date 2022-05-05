using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]//Campo obrigatório        
        [StringLength(60, MinimumLength = 3, ErrorMessage = 
            "{0} size should be between {2} and {1}")]//Valida quantidade de caracteres
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]//Campo obrigatório
        [EmailAddress(ErrorMessage = "Enter a valid email")]//Valida formato de e-mail
        [DataType(DataType.EmailAddress)]//Cria um link para o e-mail
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]//Campo obrigatório
        [Display(Name = "Birth date")]//Label
        [DataType(DataType.Date)]//Estabelece que o campo vai ter apenas a data
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//Estabelece o formato da data
        public DateTime BirthDate { get; set; }
                
        [Required(ErrorMessage = "{0} required")]//Campo obrigatório
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]//Valida o alcance do valor
        [Display(Name = "Base Salary")]//Label
        [DisplayFormat(DataFormatString = "{0:F2}")] //Formatação para 2 casas decimais "{0:F2}"
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Department")]//Label
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double salary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = salary;
            Department = department;
        }


        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Busca todos os Sales que acima da data initial e abaixo da data final
        //Em seguida soma o Amount.
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
