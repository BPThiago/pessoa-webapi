using PessoaWebApi.Model.Domain;
using PessoaWebApi.Model.DTO;
using PessoaWebApi.Model.Service;

namespace pessoa_webapi.Model.Usercase.EnderecoUsercase;

public class CreateEnderecoUsercase
{
    private EnderecoService _service;

    public CreateEnderecoUsercase(EnderecoService service)
    {
        _service = service;
    }
    
    public async Task<IResult> Execute(EnderecoDTO enderecoDto)
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

        var enderecoResponse = await _service.CreateEndereco(endereco);
        
        if (enderecoResponse is null) return TypedResults.NotFound();
        
        enderecoDto = new EnderecoDTO(enderecoResponse);
        
        return TypedResults.Created($"/{enderecoResponse.Id}", enderecoDto);
    }
}