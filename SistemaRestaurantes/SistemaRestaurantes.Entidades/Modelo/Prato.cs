using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurantes.Entidades.Modelo
{
    public class Prato
    {
        [Key]
        public int PratoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [ForeignKey("Restaurante")]
        public int IdRestaurante { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}
