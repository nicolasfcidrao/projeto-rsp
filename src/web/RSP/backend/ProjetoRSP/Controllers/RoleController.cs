using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRSP.Shared.ViewModels;
using ProjetoRSP.Infra;

namespace ProjectRSP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ProjectRSPContext _context;
        public RoleController(ProjectRSPContext context)
            => _context = context;
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleViewModel[]))]
        public IActionResult GetAll()
        {
            var roles = _context.Roles.Select(r => new RoleViewModel{
                Id = r.Id,
                Name = r.Name
            });

            return Ok(roles);
        }
    }
}