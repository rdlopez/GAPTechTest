using System;
using System.ComponentModel.DataAnnotations;

namespace GAPTechTest.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Nombre Poliza")]
        public string Name { get; set; }

        [Display(Name = "Descripción Poliza")]
        public string Description { get; set; }

        [Display(Name = "Fecha Inicio Vigencia")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Período Cobertura")]
        public int Period { get; set; }

        [Required]
        [Display(Name = "Tipo de Riesgo")]
        public ERiskType RiskType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio Poliza")]
        public float  Price { get; set; }

        public virtual Hedge Hedge { get; set; }
    }
}