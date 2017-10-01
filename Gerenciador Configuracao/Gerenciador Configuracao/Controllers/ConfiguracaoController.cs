using Gerenciador_Configuracao.Models;
using System.Linq;
using System.Web.Http;

namespace Gerenciador_Configuracao.Controllers
{
    //[Authorize]
    public class ConfiguracaoController : ApiController
    {
        private static ConfiguracaoContext ConfiguracaoContext = new ConfiguracaoContext();

        // GET api/configuracao
        public string Get()
        {
            return "result";
        }

        // GET api/configuracao/5
        public Configuracao Get(int id)
        {
            Configuracao Config = ConfiguracaoContext.Configuracoes.SingleOrDefault(conf => conf.Id == id);

            return Config;
        }

        // POST api/configuracao
        public void Post([FromBody]Configuracao value)
        {
            
        }

        // PUT api/configuracao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/configuracao/5
        public void Delete(int id)
        {
        }
    }
}
