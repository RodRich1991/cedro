using SistemaRestaurantes.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurantes.Dados.contexto
{
    public class DadosContext : DbContext
    {
        public DadosContext()
            : base("SistemaRestaurantesSiteContext")
        {

        }


        
        public DbSet<Restaurante> Restaurantes { get; set; }

        public DbSet<Prato> Pratoes { get; set; }
    }
}
