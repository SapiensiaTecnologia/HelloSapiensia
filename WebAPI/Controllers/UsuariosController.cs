

namespace APIServices.Controllers
{
    using DTO;
    using Infra.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/Usuarios")]

    public class UsuariosController : ApiController
    {

        private static UsuariosRepository _rep;
        // GET: api/Usuarios

        [HttpGet]
        [Authorize(Roles = "Admin,Consultor")]
        public IList<UsuarioDTO> Get()
        {
            _rep = new UsuariosRepository();
            IList<UsuarioDTO> usuarios = (List<UsuarioDTO>)_rep.ListAll();
            return usuarios;
        }

        // GET: api/Usuarios/5    
        [HttpGet]     
        [Authorize(Roles = "Admin,Consultor")]
        public UsuarioDTO Get(int id)
        {
            _rep = new UsuariosRepository();
            UsuarioDTO usuarios = (UsuarioDTO)_rep.GetById(id);
            return usuarios;
        }

        [HttpPost]
        // POST: api/Usuarios
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post([FromBody]UsuarioDTO dto)
        {
            _rep = new UsuariosRepository();
            try
            {
                int saved = _rep.Save(dto);
                if (saved > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível salvar os dados do Usuariose, contacte o administrador !");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        // PUT: api/Usuarios/5
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put([FromBody]UsuarioDTO dto)
        {
            _rep = new UsuariosRepository();
            try
            {
                int saved = _rep.Update(dto);
                if (saved > 0 && dto.Codigo > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível atualizar os dados do Usuariose, contacte o administrador!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        // DELETE: api/Usuarios/5
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(int id)
        {
            _rep = new UsuariosRepository();
            try
            {
                _rep.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
