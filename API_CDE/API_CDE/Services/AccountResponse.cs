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

        public string Login(string email, string password)
        {
            var account = _context.Accounts.Where(x => x.Email == email && x.Password == HashMD5(password)).FirstOrDefault();
            if (account == null)
                return "Email or password is incorrect";
            return GetToken(account);
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
                    Password = HashMD5("Add123@")
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

        public string GetToken(Account account)
        {
            var claims = new[]
         {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("IdAcc", account.IdAcc.ToString()),
            new Claim("FullName", account.FullName),
            new Claim("Role", account.Role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signIn
            );

            // Trả về token dưới dạng string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
