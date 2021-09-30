using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectApi.Models;

namespace FinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public UsersController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserDetails>>> GetTblUserDetails()
        {
            return await _context.TblUserDetails.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserDetails>> GetTblUserDetail(int id)
        {
            var tblUserDetail = await _context.TblUserDetails.FindAsync(id);

            if (tblUserDetail == null)
            {
                return NotFound();
            }

            return tblUserDetail;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserDetail(int id, TblUserDetails tblUserDetail)
        {
            if (id != tblUserDetail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(tblUserDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUserDetails>> PostTblUserDetail(TblUserDetails tblUserDetail)
        {
            if (TblUserExists(tblUserDetail.Email))
            {
                return Conflict("This email id is already registered"); ;
            }
            _context.TblUserDetails.Add(tblUserDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserDetail", new { id = tblUserDetail.UserId }, tblUserDetail);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUserDetail(int id)
        {
            var tblUserDetail = await _context.TblUserDetails.FindAsync(id);
            if (tblUserDetail == null)
            {
                return NotFound();
            }

            _context.TblUserDetails.Remove(tblUserDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUserDetailExists(int id)
        {
            return _context.TblUserDetails.Any(e => e.UserId == id);
        }

        private bool TblUserExists(string email)
        {
            return _context.TblUserDetails.Any(e => String.Equals(e.Email, email));
        }
    }
}
