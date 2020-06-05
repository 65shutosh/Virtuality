using System.Threading.Tasks;
using Virtuality.API.Models;

namespace Virtuality.API.Data
{
    public interface IUserRepository
    {
         //get user by Id
         Task<User> GetUser(int id);
    }
}