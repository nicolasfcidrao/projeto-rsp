using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRSP.Shared.Requests;
using ProjectRSP.Shared.Requests.Validators;
using ProjectRSP.Shared.ViewModels;
using ProjetoRSP.Infra;
using ProjetoRSP.Models;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaViewModel[]))]
        public IActionResult Get()
        {
            var pessoa = _context.Pessoas.Select(x => new PessoaViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Cpf = x.Cpf
            });
            return Ok(pessoa);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaViewModel))]
        public IActionResult GetById([FromRoute] GetPessoaByIdRequest request, [FromServices] GetPessoaByIdRequestValidator validator)
        {
            var validation = validator.Validate(request);
            if (!validation.IsValid)
                return BadRequest("Bad Request");
            
            var pessoa = _context.Pessoas.Where(x => x.Id == request.Id).Select(x => new PessoaViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Cpf = x.Cpf,
                Senha = x.Senha // remove this in the future
            }).FirstOrDefault();
            return Ok(pessoa);
        }

        [HttpPost]
        // TODO: Add Validator do CreatePessoaRequest
        public IActionResult Create([FromBody] CreatePessoaRequest request)
        {
            var checkPessoa = _context.Pessoas.Any(x => x.Email == request.Email && x.Cpf == request.Cpf);
            if (checkPessoa)
                return BadRequest("Pessoa já existe");

            var pessoa = new Pessoa(request.Cpf, request.Rg, request.Nome, request.Email, request.DataNascimento, request.Celular, request.Senha, request.ContatoEmergencia, request.TipoSanguineo, request.Sexo);
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            
            return Ok();
        }
        
        // TODO: Update pessoa
        [HttpPut("{id}")]
        public IActionResult Update()
        {
            return Ok();
        }
    }
}