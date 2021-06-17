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
    public class PacientesController : ControllerBase
    {
        private readonly ProjectRSPContext _context;

        public PacientesController(ProjectRSPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PacienteViewModel> Get()
        {
            return _context.Pacientes.Select(p => new PacienteViewModel
            {
                Cpf = p.Pessoa.Cpf,
                Id = p.Id,
                Nome = p.Pessoa.Nome,
                ContatoEmergencia = p.Pessoa.ContatoEmergencia,
                Rg = p.Pessoa.Rg,
                TipoSanguineo = p.Pessoa.TipoSanguineo,
                Sexo = p.Pessoa.Sexo,
                DataNascimento = p.Pessoa.DataNascimento,
                NomeDoPai = p.NomeDoPai,
                NomeDaMae = p.NomeDaMae,
                Celular = p.Pessoa.Celular,
                InfectadoCovid = p.InfectadoCovid,
                QuantasVezesInfectado = p.QuantasVezesInfectado,
                Email = p.Pessoa.Email,
                Estado = p.Estado,
                Bairro = p.Bairro,
                Cep = p.Cep,
                Cidade = p.Cidade,
                Complemento = p.Complemento,
                Logradouro = p.Logradouro,
                Numero = p.Numero
            });
        }

        [HttpGet("{pacienteId}")]
        public PacienteViewModel GetById(int pacienteId)
        {
            return _context.Pacientes.Where(p => p.Id == pacienteId).Select(p => new PacienteViewModel
            {
                Cpf = p.Pessoa.Cpf,
                Id = p.Id,
                Nome = p.Pessoa.Nome,
                ContatoEmergencia = p.Pessoa.ContatoEmergencia,
                Rg = p.Pessoa.Rg,
                TipoSanguineo = p.Pessoa.TipoSanguineo,
                Sexo = p.Pessoa.Sexo,
                DataNascimento = p.Pessoa.DataNascimento,
                NomeDoPai = p.NomeDoPai,
                NomeDaMae = p.NomeDaMae,
                Celular = p.Pessoa.Celular,
                InfectadoCovid = p.InfectadoCovid,
                QuantasVezesInfectado = p.QuantasVezesInfectado,
                Email = p.Pessoa.Email,
                Estado = p.Estado,
                Bairro = p.Bairro,
                Cep = p.Cep,
                Cidade = p.Cidade,
                Complemento = p.Complemento,
                Logradouro = p.Logradouro,
                Numero = p.Numero
            }).FirstOrDefault();
        }

        [HttpPost]
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
