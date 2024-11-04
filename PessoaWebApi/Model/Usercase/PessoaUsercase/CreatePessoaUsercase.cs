using PessoaWebApi.Model.Domain;
using PessoaWebApi.Model.DTO;
using PessoaWebApi.Model.Service;

namespace PessoaWebApi.Model.Usercase.PessoaUsercase;

public class CreatePessoaUsercase
{
    private PessoaService _service;

    public CreatePessoaUsercase(PessoaService service)
    {
        _service = service;
    }

    public async Task<IResult> Execute(PessoaDTO pessoaDto)
    {
        var pessoa = new Pessoa()
        {
            Nome = pessoaDto.Nome,
            Email = pessoaDto.Email,
            Idade = pessoaDto.Idade,
        };

        var pessoaResponse = await _service.CreatePessoa(pessoa);

        pessoaDto = new PessoaDTO(pessoaResponse);
        
        return TypedResults.Created($"/{pessoaResponse.Id}", pessoaDto);
    }
}