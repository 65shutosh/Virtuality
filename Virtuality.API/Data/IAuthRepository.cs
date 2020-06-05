using System.Threading.Tasks;
using Virtuality.API.Models;
using Virtuality.API.Dtos;

namespace Virtuality.API.Data
{
    public interface IAuthRepository
    {
        // Register a new user
        Task<User> Register(User user, string password);
        
        // login         
        Task<User> Login(string username, string password);

        // check if username already exists in dataBase
        Task<bool> UserExists(string username);

        // to check if a user is also a teacher
        Task<bool> IsTeacher( int id);  

        // register an existing user as a teacher
        Task<bool> RegisterAsTeacher(Teacher teacher);       
    }
}