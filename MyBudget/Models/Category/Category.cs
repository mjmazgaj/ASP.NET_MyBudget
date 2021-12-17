﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models
{
    [Table("Categories")]

    public class Category
    {

        [Key]
        [DisplayName("ID")]
        public int IdCat { get; set; }
        [DisplayName("Kategoria")]
        [Required(ErrorMessage = "Podanie nazwy jest wymagane.")]
        [MaxLength(50)]
        public string NameCat { get; set; }
    }
}