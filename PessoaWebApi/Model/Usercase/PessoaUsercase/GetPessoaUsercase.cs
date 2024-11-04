using PessoaWebApi.Model.DTO;
using PessoaWebApi.Model.Service;

namespace PessoaWebApi.Model.Usercase.PessoaUsercase;

public class GetPessoaUsercase
{
    private PessoaService _service;

    public GetPessoaUsercase(PessoaService service)
    {
        _service = service;
    }

    public async Task<IResult> Execute(int id)
    {
        var pessoa = await _service.GetPessoa(id);
        return pessoa is not null
            ? TypedResults.Ok(new PessoaDTO(pessoa))
            : TypedResults.NotFound();
    }
}