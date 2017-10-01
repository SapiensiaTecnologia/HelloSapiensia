using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador_Configuracao.Models
{
    // Modelos usados como parâmetros para as ações AccountController.
    [Table("ApsNetConfiguracao")]
    public class Configuracao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Cor do texto")]
        public string Color { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Font family color")]
        public string FontFamily { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Alinhamento do texto")]
        public string TextAlign { get; set; }
    }

}
