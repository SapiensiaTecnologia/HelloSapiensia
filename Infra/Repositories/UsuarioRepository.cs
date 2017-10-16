

namespace Infra.Repositories
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class UsuariosRepository : IRepository
    {

        /// <summary>
        /// Method constructor in here we mapped dto to entitie and reverse by automapper
        /// </summary>
        public UsuariosRepository()
        {

        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IDTO GetById(int codigo)
        {
            UsuarioDTO obj;
            using (var db = new modelEntities())
            {
                // Display all Blogs from the database 
                var query = from b in db.Usuarios where b.codigo == codigo select b;
                Usuario usuarios = query.FirstOrDefault();
                obj = Mapper.Map<Usuario, UsuarioDTO>(usuarios);
            }


            return obj;
        }

        /// <summary>
        /// to delete a user from database
        /// </summary>
        /// <param name="id">the id primary key from object</param>
        public void Delete(int codigo)
        {
            try
            {
                UsuarioDTO obj = new UsuarioDTO();
                using (var db = new modelEntities())
                {
                    // Display all Blogs from the database 
                    var query = from b in db.Usuarios where b.codigo == codigo select b;
                    Usuario usuarios = query.FirstOrDefault();
                    //Delete it from memory
                    db.Usuarios.Remove(usuarios);
                    //Save to database\ 
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IEnumerable<IDTO> ListAll()
        {
            IEnumerable<IDTO> AllObj = new List<UsuarioDTO>();
                using (var db = new modelEntities())
                {
                    // Display all usuarios from the database 
                    var query = from b in db.Usuarios select b;
                    List<Usuario> list = query.ToList();
                    AllObj = Mapper.Map<List<Usuario>, List<UsuarioDTO>>(list);

                }


                return AllObj;
            
        }

              

        /// <summary>
        /// to insert a new object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Save(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    Usuario usuario = Mapper.Map<Usuario>(dto);

                    using (var db = new modelEntities())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {

                            var query = from b in db.Perfils where b.codigo == usuario.perfil_id select b;
                            Perfil perfil = query.ToList().SingleOrDefault();
                            usuario.Perfil = perfil;
                            // Display all usuarios from the database                        
                            db.Usuarios.Add(usuario);
                            id = db.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// to update an object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Update(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    Usuario usuarios = Mapper.Map<Usuario>(dto);
                    using (var db = new modelEntities())
                    {
                        //var query = from b in db.Perfils where b.codigo == usuarios.perfil_id select b;
                        //Perfil perfil = query.ToList().SingleOrDefault();
                        // Display all usuarios from the database                        
                        db.Entry(usuarios).State = System.Data.Entity.EntityState.Modified;
                        id = db.SaveChanges();

                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// function to validate if this dto is according into business rules
        /// </summary>
        /// <param name="dto">a dto which will be validated</param>
        public bool ValidateEntitie(IDTO dto)
        {
            UsuarioDTO usuariosDTO = (UsuarioDTO)dto;
            bool validated = false;
            if (string.IsNullOrEmpty(usuariosDTO.Nome) || string.IsNullOrWhiteSpace(usuariosDTO.Nome))
            {
                throw new Exception("O campo nome é obrigatório");
            }
            else
            {
                validated = true;
            }
            return validated;
        }

    }
}
