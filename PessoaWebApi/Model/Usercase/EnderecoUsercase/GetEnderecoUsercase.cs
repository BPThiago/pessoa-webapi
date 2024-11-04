using PessoaWebApi.Model.DTO;
using PessoaWebApi.Model.Service;

namespace pessoa_webapi.Model.Usercase.EnderecoUsercase;

public class GetEnderecoUsercase
{
    private EnderecoService _service;

    public GetEnderecoUsercase(EnderecoService service)
    {
        _service = service;
    }

    public async Task<IResult> Execute(int id)
    {
        var endereco = await _service.GetEndereco(id);
        return endereco is not null
            ? TypedResults.Ok(new EnderecoDTO(endereco))
            : TypedResults.NotFound();
    }
}