using Microsoft.AspNetCore.Mvc;
using PessoaWebApi.Model;
using PessoaWebApi.Model.DTO;

namespace PessoaWebApi.Controller
{
    [Route("/endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private PessoaDb _db;

        public EnderecoController(PessoaDb db)
        {
            _db = db;
        }
        
        [HttpGet("{id}")]
        public async Task<IResult> GetEndereco(int id)
        {
            return await _db.Enderecos.FindAsync(id)
                is Endereco endereco
                ? TypedResults.Ok(new EnderecoDTO(endereco))
                : TypedResults.NotFound();
        }
        
        [HttpPost]
        public async Task<IResult> CreateEndereco(EnderecoDTO enderecoDto)
        {
            var endereco = new Endereco()
            {
                PessoaId = enderecoDto.PessoaId,
                Logradouro = enderecoDto.Logradouro,
                Numero = enderecoDto.Numero,
                Estado = enderecoDto.Estado,
                Cidade = enderecoDto.Cidade,
                Bairro = enderecoDto.Bairro,
            };
            
            _db.Enderecos.Add(endereco);
            
            var pessoa = await _db.Pessoas.FindAsync(enderecoDto.PessoaId);
            
            if (pessoa is null) return TypedResults.NotFound();
            
            pessoa.Enderecos.Add(endereco);
            await _db.SaveChangesAsync();
            
            enderecoDto = new EnderecoDTO(endereco);
            
            return TypedResults.Created($"/{endereco.Id}", enderecoDto);
        }
    }
}