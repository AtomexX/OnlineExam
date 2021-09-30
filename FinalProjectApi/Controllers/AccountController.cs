using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FinalProjectApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace FinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ProjectDBContext _context;

        public AccountController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TblUserDetails>> Post(TblUserDetails _account)
        {
            if (_account != null && _account.Email != null && _account.Password != null)
            {
                TblUserDetails accountCustomer = await GetAccount(_account.Email, _account.Password);

                if (accountCustomer != null)
                {
                    return accountCustomer;
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("invalid");
            }
        }

        private async Task<TblUserDetails> GetAccount(string email, string password)
        {
            return await _context.TblUserDetails.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

    }
}
