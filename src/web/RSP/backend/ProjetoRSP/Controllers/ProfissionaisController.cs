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
    public class ProfissionaisController : ControllerBase
    {
        private readonly ProjectRSPContext _context;

        public ProfissionaisController(ProjectRSPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ProfissionalViewModel> Get()
        {
            return _context.Profissionais.Select(p => new ProfissionalViewModel
            {
                Id = p.Id,
                Nome = p.Pessoa.Nome,
                CodProfissional = p.CodProfissional
            });
        }

        [HttpGet("{profissionalId}")]
        public ProfissionalViewModel GetById(int profissionalId)
        {
            return _context.Profissionais.Where(p => p.Id == profissionalId).Select(p => new ProfissionalViewModel
            {
                Id = p.Id,
                Nome = p.Pessoa.Nome,
                CodProfissional = p.CodProfissional
            }).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post(ProfissionalRequest request)
        {
            if (_context.Pessoas.Any(p => p.Cpf == request.Cpf || p.Email == request.Email || p.Rg == request.Rg))
                return BadRequest("Pessoa já existe na base de dadox :(");

            var pessoa = new Pessoa(request.Cpf, request.Rg, request.Nome, request.Email, request.DataNascimento, request.Celular, request.Senha);
            var profissional = new Profissional(request.CodProfissional, request.Especialidade, request.RazaoSocial, request.Cnpj, default);
            profissional.Pessoa = pessoa;
            _context.Profissionais.Add(profissional);
            _context.SaveChanges();

            return Ok();
        }
    }
}
