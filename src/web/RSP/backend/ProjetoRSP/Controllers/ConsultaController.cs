using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoRSP.Infra;
using ProjetoRSP.Models;
using ProjetoRSP.Shared.Requests;
using ProjetoRSP.Shared.ViewModels;

namespace ProjetoRSP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly ProjectRSPContext _context;

        public ConsultaController(ProjectRSPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ConsultaViewModel> Get()
        {
            return _context.Consultas.Select(p => new ConsultaViewModel
            {
                Id = p.Id,
                PacienteId = p.Paciente.Id,
                NomePaciente = p.Paciente.Pessoa.Nome,
                ProfissionalId = p.Profissional.Pessoa.Id,
                ProfissionalNome = p.Profissional.Pessoa.Nome,
                CodProfissional = p.Profissional.CodProfissional
            });
        }

        [HttpPost]
        public IActionResult Post(ConsultasRequest request)
        {
            var consulta = new Consulta(request.DataConsulta, request.PacienteId, request.ProfissionalId);
            _context.Consultas.Add(consulta);
            _context.SaveChanges();

            return Ok();
        }
    }
}
