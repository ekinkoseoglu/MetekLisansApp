using MetekLisansApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
namespace MetekLisansApp.Utility
{
    public class TokenHelper
    {
        private readonly ApplicationDbContext _context;
        //Import Configuration
        private readonly IConfiguration _configuration;
        public TokenHelper(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }
        public string GenerateToken(string username, string password)
        {
            string? secretKey = _configuration["Secret-Token"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Secret key is not configured.");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                string tokenInput = username + password + secretKey;
                byte[] tokenBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(tokenInput));
                return BitConverter.ToString(tokenBytes).Replace("-", "").ToLower();
            }
        }
        
        public  async Task<bool> CheckUserAuthhentication(HttpContext httpContext)
        {
            var sessionToken = httpContext.Session.GetString("userToken");
            var kullaniciId = httpContext.Session.GetString("KullaniciId");
            if (string.IsNullOrEmpty(kullaniciId))
            {
                return false;
            }

            var kullanici = await _context.Kullanicilar.FindAsync(Convert.ToInt32(kullaniciId));
            if (kullanici == null)
            {
                return false;
            }

            var generatedToken = GenerateToken(kullanici.KullaniciAdi, kullanici.Sifre);
            if (sessionToken != generatedToken)
            {
                return false;
            }

            return true;
        }
    }

    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
