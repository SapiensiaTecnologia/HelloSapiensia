
namespace Tests
{
    using DTO;
    using Infra.Mappers;
    using Infra.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class ConfiguracaoTest
    {
        private ConfiguracaoRepository rep = new ConfiguracaoRepository();



        [TestMethod]
        public void ListAllConfiguracaoTest()
        {
            AutoMapperConfig.RegisterMappings();
            List<ConfiguracaoDTO> Configuracaos = (List<ConfiguracaoDTO>)rep.ListAll();
            Assert.IsTrue(Configuracaos.Count > 0);

        }
        [TestMethod]
        public void UpdateAClientTest()
        {
            AutoMapperConfig.RegisterMappings();
            ConfiguracaoDTO dto = new ConfiguracaoDTO();
            dto.Codigo = 4;
            dto.Nome = "TESTE 2";
            dto.Valor = "NOVO 2";
            dto.PerfilId = 2;            
            rep.Update(dto);
        }

        [TestMethod]
        public void SaveAClientTest()
        {
            AutoMapperConfig.RegisterMappings();
            ConfiguracaoDTO dto = new ConfiguracaoDTO();
            dto.Codigo = 4;
            dto.Nome = "TESTE 2";
            dto.Valor = "NOVO 2";
            dto.PerfilId = 2;
            rep.Save(dto);
        }

        [TestMethod]
        public void DeletelientTest()
        {

            rep.Delete(1);
        }
    }
}
