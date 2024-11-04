using PessoaWebApi.Model.Domain;

namespace PessoaWebApi.Model.DTO;

public class EnderecoDTO
{
    public int Id { get; set; }
    public int PessoaId { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }

    public EnderecoDTO()
    {
    }
    
    public EnderecoDTO(Endereco endereco) =>
        (Id, PessoaId, Logradouro, Numero, Estado, Cidade, Bairro) = (endereco.Id, endereco.PessoaId, endereco.Logradouro, endereco.Numero, endereco.Estado, endereco.Cidade, endereco.Bairro);
}