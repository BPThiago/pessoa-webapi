using PessoaWebApi.Model.Service;

namespace PessoaWebApi.Model.Usercase.PessoaUsercase;

public class GetAllPessoasUsercase
{
    private PessoaService _service;

    public GetAllPessoasUsercase(PessoaService service)
    {
        _service = service;
    }

    public async Task<IResult> Execute()
    {
        var pessoas = await _service.GetAllPessoas();
        return TypedResults.Ok(pessoas);
    }
}