using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLCrudAirplane.Domain.Entidades
{
    [Table("Airplane")]
    public class Airplane
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Modelo { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int QuantidadePassageiros { get; set; }

        [Required]
        [Column(TypeName = "smallDatetime")]
        public DateTime CriadoEm { get; set; }
    }
}
