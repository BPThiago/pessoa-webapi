using Microsoft.EntityFrameworkCore;
using PessoaWebApi.Model.Domain;

namespace PessoaWebApi.Model.Service;

public class PessoaService
{
    private PessoaDb _db;

    public PessoaService(PessoaDb db)
    {
        _db = db;
    }

    public async Task<Pessoa[]> GetAllPessoas()
    {
        var pessoas = await _db.Pessoas
            .Include(pessoa => pessoa.Enderecos)
            .ToArrayAsync();
        return pessoas;
    }

    public async Task<Pessoa?> GetPessoa(int id)
    {
        var pessoa = await _db.Pessoas
            .Include(pessoa => pessoa.Enderecos)
            .FirstOrDefaultAsync(pessoa => pessoa.Id == id);
        return pessoa;
    }

    public async Task<Pessoa> CreatePessoa(Pessoa pessoa)
    {
        _db.Pessoas.Add(pessoa);
        await _db.SaveChangesAsync();
        return pessoa;
    }
}