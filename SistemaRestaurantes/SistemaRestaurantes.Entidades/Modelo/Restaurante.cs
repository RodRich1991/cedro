using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurantes.Entidades.Modelo
{
    public class Restaurante
    {
        [Key]
        public int RestauranteId { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
