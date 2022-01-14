using CRUD_Resonsive_Web_API.Models;
using System.Threading.Tasks;

namespace CRUD_Resonsive_Web_API.Interfaces
{
    public interface IAccountService
    {
       Task<bool> ValidateCredentials(string username, string password, out Account account);
    }
}
