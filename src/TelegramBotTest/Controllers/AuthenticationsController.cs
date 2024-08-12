using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NodeJurnalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : BaseController
    {
        IConfiguration configuration;

        public AuthenticationsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] GetAllUserPermissionQuery command)
        {

            if (!GetMd5Sum(command.Passsword).Equals(configuration["PasswordHash"])) return new ForbidResult();
            var claims = new List<Claim>();
            var userName = new Claim("UserName", "Administrator");
            claims.Add(userName);
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(50)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = "Aministrator",

            };

            return Ok(response);
        }
        private string GetMd5Sum(string password)
        {
            string salt = "My_Salt";
            var bsalt = Encoding.UTF8.GetBytes(salt);
            var bpassword = Encoding.UTF8.GetBytes(password);
            var hmacMD5 = new System.Security.Cryptography.HMACMD5(bsalt);
            var saltedHash = hmacMD5.ComputeHash(bpassword);
            return Convert.ToBase64String(saltedHash);
        }
    }
}
