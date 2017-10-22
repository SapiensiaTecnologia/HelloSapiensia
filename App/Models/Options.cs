using System;
using System.Collections.Generic;

namespace gerenciadorDeConfiguracao.Models
{
    public partial class Options
    {
        public int Id { get; set; }
        public string Temperatura { get; set; }
        public string Hora { get; set; }
        public string Data { get; set; }
    }
}
