using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gerenciador_Configuracao.Models
{
    public class ConfiguracaoContext : DbContext
    {
        public DbSet<Configuracao> Configuracoes { get; set; } 
    }
}