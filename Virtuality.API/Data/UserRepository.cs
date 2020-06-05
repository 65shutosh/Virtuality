using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Virtuality.API.Models;

namespace Virtuality.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<User> GetUser(int id)
        {
           var user =  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}