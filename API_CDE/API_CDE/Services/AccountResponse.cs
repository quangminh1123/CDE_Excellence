using API_CDE.Data;
using API_CDE.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace API_CDE.Services
{
    public class AccountResponse : IAccount
    {
        private readonly ApplicationDBContext _context;
        private IConfiguration _configuration;
        public AccountResponse(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Account AddUser(string fullName, string email, int? idPosition, string status)
        {
            try
            {
                var emailExit = _context.Accounts.Where(x => x.Email == email).FirstOrDefault();
                if (emailExit != null)
                    return null;
                var account = new Account()
                {
                    FullName = fullName,
                    Email = email,
                    IdPosition = idPosition,
                    Status = status,
                    Role = "Người dùng",
                    Password = HashMD5("Add1123@")
                };
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return account;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<Account> UserList()
        {
            return _context.Accounts;
        }

        public Account UpdateUser(int id, string fullName, string email, int? idPosition, string status)
        {
            try
            {
                var emailExit = _context.Accounts.Where(x => x.Email == email).FirstOrDefault();
                if (emailExit != null)
                    return null;
                var us = _context.Accounts.Find(id);
                if (us == null)
                    return null;
                us.FullName = fullName;
                us.Email = email;
                us.IdPosition = idPosition;
                us.Status = status;
                _context.SaveChanges();
                return us;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string HashMD5(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] passBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(passBytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
