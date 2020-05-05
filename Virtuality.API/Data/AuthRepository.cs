using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Virtuality.API.Models;

namespace Virtuality.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }

//# Login Method

        public async Task<User> Login(string username, string password)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x => x.Username == username);     

        // returning null if user is not present
            if (user == null) return null;

        // Vaifying hashPassword  and return null if match not found
        if(!VarifyPasswordHash(password,user.PasswordHash,user.PasswordSalt)) return null;
           
        return user;

       }

// varifying hash password using saltPassword  
        private bool VarifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // generating Hmac object using passwordSalt
           using( var hmac =new System.Security.Cryptography.HMACSHA512(passwordSalt)){
            
            var computedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            //matching computedHashPassword and HashPassword
            for (int i = 0; i <computedPasswordHash.Length; i++)
            {
                if(computedPasswordHash[i] != passwordHash[i]) return false;
            }
          }
          return true;
        }


        //# Registering a user in database
        public  async Task<User> Register(User user, string password)
        {
           byte[] passwordHash , passwordSalt ;
           CreatePasswordHash(password ,out passwordHash ,out passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

           return user;
        }

//# This function is to create Hash and Salt PassWord which will be called by Register() method
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
          using( var hmac =new System.Security.Cryptography.HMACSHA512()){
              passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
          }
        }

// Checking if username/user exists in database
        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username)) return true;

            return false;
            
        }
    }
}