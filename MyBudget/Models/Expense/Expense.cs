using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBudget.Models
{
    [Table("Expenses")]
    public class Expense
    {
        [Key]
        public int IdExp { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Podanie nazwy jest wymagane.")]
        [MaxLength(50)]
        public string NameExp { get; set; }
        [DisplayName("Cena")]
        [Required(ErrorMessage = "Podanie ceny jest wymagane.")]
        public decimal ValueExp { get; set; }
        [DisplayName("Data")]
        public DateTime DateExp { get; set; }
        public int IdCat { get; set; }
        [DisplayName("Opis")]
        public string DescriptionExp { get; set; }

        [ForeignKey("IdCat")]
        public Category Category { get; set; }
    }
}