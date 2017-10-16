

namespace APIServices.Controllers
{
    using DTO;
    using Infra.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/Configuracao")]

    public class ConfiguracaoController : ApiController
    {

        private static ConfiguracaoRepository _rep;
        // GET: api/Configuracao

        [HttpGet]
        [Authorize(Roles = "Admin,Consultor")]
        public IList<ConfiguracaoDTO> Get()
        {
            _rep = new ConfiguracaoRepository();
            IList<ConfiguracaoDTO> Configuracaos = (List<ConfiguracaoDTO>)_rep.ListAll();
            return Configuracaos;
        }

        // GET: api/Configuracao/5    
        [HttpGet]
        [Authorize(Roles = "Admin,Consultor")]
        public ConfiguracaoDTO Get(int id)
        {
            _rep = new ConfiguracaoRepository();
            ConfiguracaoDTO Configuracao = (ConfiguracaoDTO)_rep.GetById(id);
            return Configuracao;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        // POST: api/Configuracao
        public HttpResponseMessage Post([FromBody]ConfiguracaoDTO dto)
        {
            _rep = new ConfiguracaoRepository();
            try
            {
                int saved = _rep.Save(dto);
                if (saved > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível salvar os dados do Configuracaoe, contacte o administrador !");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        // PUT: api/Configuracao/5
        public HttpResponseMessage Put([FromBody]ConfiguracaoDTO dto)
        {
            _rep = new ConfiguracaoRepository();
            try
            {
                int saved = _rep.Update(dto);
                if (saved > 0 && dto.Codigo > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Não foi possível atualizar os dados do Configuracaoe, contacte o administrador!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        // DELETE: api/Configuracao/5
        public HttpResponseMessage Delete(int id)
        {
            _rep = new ConfiguracaoRepository();
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
