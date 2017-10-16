using DTO;

namespace Infra.Repositories
{
    public interface ILoginRepository
    {
        
        bool RegisterUsuario(string login, string pwd);
        IDTO GetUsuario(string login, string pwd);
    }
}