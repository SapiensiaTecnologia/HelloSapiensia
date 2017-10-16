

namespace Infra.Repositories
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LoginRepository : ILoginRepository
    {

        /// <summary>
        /// Method constructor in here we mapped dto to entitie and reverse by automapper
        /// </summary>
        public LoginRepository()
        {

        }


        /// <summary>
        ///  Este método deve ser utilizado para preenchimento de clains
        /// </summary>
        /// <param name="login">o login do usuário </param>
        /// <param name="pwd">a senha do usuário </param>
        /// <returns>Retorna o usuário</returns>
        public IDTO GetUsuario(string login, string pwd)
        {
            IDTO usuarioDTO = new UsuarioDTO();
            using (var db = new modelEntities())
            {
                // Display all Blogs from the database 
                var query = from b in db.Usuarios where b.nickName == login && b.senha == pwd select b;
                Usuario usuario = query.FirstOrDefault();
                usuarioDTO = Mapper.Map<UsuarioDTO>(usuario); 
            }

            return usuarioDTO;
        }

        /// <summary>
        /// Este método retorna se o usuário existe com acesso registrado no bd
        /// para utilizar o sistema
        /// </summary>
        /// <param name="login">o login do usuário </param>
        /// <param name="pwd">a senha do usuário </param>
        /// <returns>retorna verdadeiro ou falso</returns>
        public bool RegisterUsuario(string login, string pwd)
        {
            bool encontrou = false;
            using (var db = new modelEntities())
            {
                // Display all Blogs from the database 
                var query = from b in db.Usuarios where b.nickName == login && b.senha==pwd select b;
                Usuario usuario = query.FirstOrDefault();
                encontrou = usuario.perfil_id > 0 ? true : false;
            }

            return encontrou;
        }

     
    }
}
