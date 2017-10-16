

namespace APIServices.Controllers
{
    using DTO;
    using Infra.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/Perfil")]

    public class PerfilController : ApiController
    {

        private static PerfilRepository _rep;
        // GET: api/Perfil

        [HttpGet]
        [Authorize(Roles = "Admin,Consultor")]
        public IList<PerfilDTO> Get()
        {
            _rep = new PerfilRepository();
            IList<PerfilDTO> Perfils = (List<PerfilDTO>)_rep.ListAll();
            return Perfils;
        }

        // GET: api/Perfil/5    
        [HttpGet]
        [Authorize(Roles = "Admin,Consultor")]
        public PerfilDTO Get(int id)
        {
            _rep = new PerfilRepository();
            PerfilDTO Perfil = (PerfilDTO)_rep.GetById(id);
            return Perfil;
        }

        [HttpPost]
        // POST: api/Perfil
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post([FromBody]PerfilDTO dto)
        {
            _rep = new PerfilRepository();
            try
            {
                int saved = _rep.Save(dto);
                if (saved > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível salvar os dados do Perfile, contacte o administrador !");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        // PUT: api/Perfil/5
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put([FromBody]PerfilDTO dto)
        {
            _rep = new PerfilRepository();
            try
            {
                int saved = _rep.Update(dto);
                if (saved > 0 && dto.Codigo > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível atualizar os dados do Perfile, contacte o administrador!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        // DELETE: api/Perfil/5
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(int id)
        {
            _rep = new PerfilRepository();
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
