using CRUD_Reponsive_Web_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_Reponsive_Web_API.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUser(UserModel user, bool forUnitTest = false);
        Task<bool> EditUser(string id, UserModel user);
        Task<bool> DeleteUser(string id);
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUser(string id);
    }
}
