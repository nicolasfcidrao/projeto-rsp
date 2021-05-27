using Microsoft.AspNetCore.Mvc;
using ProjetoRSP.Infra;

namespace ProjectRSP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ProjectRSPContext _context;

        public PessoaController(ProjectRSPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        
    }
}