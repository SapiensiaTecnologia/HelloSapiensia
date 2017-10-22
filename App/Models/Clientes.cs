using System;
using System.Collections.Generic;

namespace gerenciadorDeConfiguracao.Models
{
    public partial class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
