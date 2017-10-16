
namespace Infra.Repositories
{
    using DTO;
    using System.Collections.Generic;

    /// <summary>
    /// This interface is responsible to render a unique pattern for all repositories, 
    /// which this design pattern we can use one Interface for all repositories.
    /// </summary>
    interface IRepository
    {
        int Save(IDTO dto);
        IEnumerable<IDTO> ListAll();
        int Update(IDTO dto);
        void Delete(int codigo);
        bool ValidateEntitie(IDTO dto);
        IDTO GetById(int codigo);

    }
}
