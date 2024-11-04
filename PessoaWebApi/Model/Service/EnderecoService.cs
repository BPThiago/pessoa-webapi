using PessoaWebApi.Model.Domain;

namespace PessoaWebApi.Model.Service;

public class EnderecoService
{
    private PessoaDb _db;

    public EnderecoService(PessoaDb db)
    {
        _db = db;
    }

    public async Task<Endereco?> GetEndereco(int id)
    {
        return await _db.Enderecos.FindAsync(id);
    }

    public async Task<Endereco?> CreateEndereco(Endereco endereco)
    {
        var pessoa = await _db.Pessoas.FindAsync(endereco.PessoaId);
        
        if (pessoa == null) return null;
        
        pessoa.Enderecos.Add(endereco);
        
        _db.Enderecos.Add(endereco);
        await _db.SaveChangesAsync();
        return endereco;
    }
}