namespace DTO
{
   public class ConfiguracaoDTO : IDTO
    {
        /// <summary>
        /// Código do Configuração
        /// </summary>        
        public int Codigo { get; set; }
        /// <summary>
        /// Nome do Configuração
        /// </summary> 
        public string Nome { get; set; }
        /// <summary>
        /// tipo of client "fisica / juridica"
        /// </summary> 
        public string Valor { get; set; }
        /// <summary>
        /// id do perfil da configuração  no banco
        /// </summary> 
        public int PerfilId { get; set; }
        /// <summary>
        /// Descrição do perfil da configuração no banco
        /// </summary> 
        public string PerfilNome { get; set; }
    }
}
