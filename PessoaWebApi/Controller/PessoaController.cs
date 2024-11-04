using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PessoaWebApi.Model;
using PessoaWebApi.Model.DTO;

namespace PessoaWebApi.Controller
{
    [Route("/")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private PessoaDb _db;

        public PessoaController(PessoaDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> GetAllPessoas()
        {
            var pessoas = await _db.Pessoas
                .Include(pessoa => pessoa.Enderecos)
                .Select(pessoa => new PessoaDTO(pessoa))
                .ToArrayAsync();
            return TypedResults.Ok(pessoas);
        }
        
        [HttpGet("{id}")]
        public async Task<IResult> GetPessoa(int id)
        {
            var pessoa = await _db.Pessoas
                .Include(pessoa => pessoa.Enderecos)
                .FirstOrDefaultAsync(pessoa => pessoa.Id == id);
            return pessoa is not null
                ? TypedResults.Ok(new PessoaDTO(pessoa))
                : TypedResults.NotFound();
        }

        [HttpPost]
        public async Task<IResult> CreatePessoa(PessoaDTO pessoaDto)
        {
            var pessoa = new Pessoa()
            {
                Nome = pessoaDto.Nome,
                Email = pessoaDto.Email,
                Idade = pessoaDto.Idade,
            };
            
            _db.Pessoas.Add(pessoa);
            await _db.SaveChangesAsync();
            
            pessoaDto = new PessoaDTO(pessoa);
            
            return TypedResults.Created($"/{pessoa.Id}", pessoaDto);
        }
    }
}