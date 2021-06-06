using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoRSP.Infra;
using ProjetoRSP.Models;
using ProjetoRSP.Shared.Requests;
using ProjetoRSP.Shared.ViewModels;

namespace ProjetoRSP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly ProjectRSPContext _context;

        public PacientesController(ProjectRSPContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<PacienteViewModel> Get()
        {
            return _context.Pacientes.Select(p => new PacienteViewModel
            {
                Id = p.Id,
                Nome = p.Pessoa.Nome
            });
        }

        [HttpGet("{pacienteId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public PacienteViewModel GetById(int pacienteId)
        {
            return _context.Pacientes.Where(p => p.Id == pacienteId).Select(p => new PacienteViewModel
            {
                Id = p.Id,
                Nome = p.Pessoa.Nome
            }).FirstOrDefault();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public IActionResult Post(PacienteRequest request)
        {
            if (_context.Pessoas.Any(p => p.Cpf == request.Cpf || p.Email == request.Email || p.Rg == request.Rg))
                return BadRequest("Pessoa já existe na base de dadox :(");

            var pessoa = new Pessoa(request.Cpf, request.Rg, request.Nome, request.Email, request.DataNascimento, request.Celular, request.Senha, request.ContatoEmergencia, request.TipoSanguineo, request.Sexo);
            var paciente = new Paciente(request.Logradouro, request.Numero, request.Bairro, request.Cidade, request.Estado, request.Celular, default, request.Complemento, request.NomeDaMae, request.NomeDoPai, request.InfectadoCovid, request.QuantasVezesInfectado);
            paciente.Pessoa = pessoa;
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{pacienteId}")]
        public IActionResult Delete(int pacienteId)
        {
            Paciente p = new Paciente();
            p.Id = pacienteId;
            _context.Remove(p);
            _context.SaveChanges();
            return Ok();
        }
    }
}
