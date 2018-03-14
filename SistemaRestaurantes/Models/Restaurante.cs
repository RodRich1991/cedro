using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CedroBackend.Models
{
    public class Restaurante
    {
        [Key]
        public int RestauranteId { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}