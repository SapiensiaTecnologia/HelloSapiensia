namespace DTO
{
   public class UsuarioDTO : IDTO
    {
        /// <summary>
        /// Código of usuário
        /// </summary>        
        public int Codigo { get; set; }

        /// <summary>
        /// Nome of usuário
        /// </summary> 
        public string Nome { get; set; }
        /// <summary>
        /// Nome of usuário
        /// </summary> 
        public string Login { get; set; }
        /// <summary>
        /// Senha of usuário
        /// </summary> 
        public string Senha { get; set; }
        /// <summary>
        /// id do perfil daquele usuário no banco
        /// </summary> 
        public int PerfilId { get; set; }
       
        /// <summary>
        /// Descrição do perfil daquele usuário no banco
        /// </summary>
        public string PerfilNome { get; set; }
    }
}
