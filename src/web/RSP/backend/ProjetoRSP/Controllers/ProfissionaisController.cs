using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoRSP.Infra;
using ProjetoRSP.Models;
using ProjetoRSP.Shared.Requests;
using ProjetoRSP.Shared.Requests.Validators;
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
                Cpf = p.Pessoa.Cpf,
                Id = p.Id,
                Nome = p.Pessoa.Nome,
                CodProfissional = p.CodProfissional,
                Email = p.Pessoa.Email,
                Celular = p.Pessoa.Celular,
                ContatoEmergencia = p.Pessoa.ContatoEmergencia,
                Especialidade1 = p.Especialidade1,
                Especialidade2 = p.Especialidade2,
                Rg = p.Pessoa.Rg,
                RazaoSocial1 = p.RazaoSocial1,
                RazaoSocial2 = p.RazaoSocial2,
                Cnpj = p.Cnpj,
                DataNascimento = p.Pessoa.DataNascimento,
                Sexo = p.Pessoa.Sexo,
                TipoSanguineo = p.Pessoa.TipoSanguineo
            });
        }

        [HttpGet("{profissionalId}")]
        public ProfissionalViewModel GetById(int profissionalId)
        {
            return _context.Profissionais.Where(p => p.Id == profissionalId).Select(p => new ProfissionalViewModel
            {
                Cpf = p.Pessoa.Cpf,
                Id = p.Id,
                Nome = p.Pessoa.Nome,
                CodProfissional = p.CodProfissional,
                Email = p.Pessoa.Email,
                Celular = p.Pessoa.Celular,
                ContatoEmergencia = p.Pessoa.ContatoEmergencia,
                Especialidade1 = p.Especialidade1,
                Especialidade2 = p.Especialidade2,
                Rg = p.Pessoa.Rg,
                RazaoSocial1 = p.RazaoSocial1,
                RazaoSocial2 = p.RazaoSocial2,
                Cnpj = p.Cnpj,
                DataNascimento = p.Pessoa.DataNascimento,
                Sexo = p.Pessoa.Sexo,
                TipoSanguineo = p.Pessoa.TipoSanguineo
            }).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post(ProfissionalRequest request, [FromServices] ProfissionalRequestValidator validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            if (_context.Pessoas.Any(p => p.Cpf == request.Cpf || p.Email == request.Email || p.Rg == request.Rg))
                return BadRequest("Pessoa já existe na base de dadox :(");

            var pessoa = new Pessoa(request.Cpf, request.Rg, request.Nome, request.Email, request.DataNascimento, request.Celular, request.Senha, request.ContatoEmergencia, request.TipoSanguineo, request.Sexo);
            var profissional = new Profissional(request.CodProfissional, request.Especialidade1, request.Especialidade2, request.RazaoSocial1, request.RazaoSocial2, request.Cnpj, default);
            profissional.Pessoa = pessoa;
            _context.Profissionais.Add(profissional);
            _context.SaveChanges();

            return Ok();
        }
    }
}
