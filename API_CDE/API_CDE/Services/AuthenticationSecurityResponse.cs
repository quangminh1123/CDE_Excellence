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
    public class AuthenticationSecurityResponse : IAuthenticationSecurity
    {
        private readonly ApplicationDBContext _context;
        private IConfiguration _configuration;
        public AuthenticationSecurityResponse(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string Login(string email, string password)
        {
            try
            {
                var account = _context.Accounts.Where(x => x.Email.ToLower() == email.ToLower() && x.Password == HashMD5(password)).FirstOrDefault();
                if (account == null)
                    return "Email or password is incorrect";
                return GetToken(account);
            }
            catch (Exception ex)
            {

                return ($"Error: {ex.Message}");
            }
        }

        public string ChangePassword(int id, string password)
        {
            try
            {
                if (!IsValidPassword(password))
                    return "Password must be at least 8 characters including lower case, upper case, digital numbers and special characters";
                var acc = _context.Accounts.Find(id);
                if (acc == null)
                    return "Not found";
                acc.Password = HashMD5(password);
                _context.SaveChanges();
                return "Update Success";
            }
            catch (Exception)
            {

                return "Cannot change password";
            }
        }

        public string ResetPassword(int id)
        {
            try
            {
                var acc = _context.Accounts.Find(id);
                if (acc == null)
                    return "Not found";
                if (acc.Role == "Owner")
                    return "Cannot update Owner password";
                acc.Password = HashMD5("Add1123@");
                _context.SaveChanges();
                return "Update Success";
            }
            catch (Exception)
            {

                return "Cannot reset password";
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
            new Claim(ClaimTypes.Role, account.Role)
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
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }
    }
}
