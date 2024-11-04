using System.Collections;
using PessoaWebApi.Model.Domain;

namespace PessoaWebApi.Model.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public List<EnderecoDTO>? Enderecos { get; set; }

        public PessoaDTO()
        {
        }
        
        public PessoaDTO(Pessoa pessoa) =>
            (Id, Nome, Idade, Email, Enderecos) = (pessoa.Id, pessoa.Nome, pessoa.Idade, pessoa.Email, pessoa.Enderecos.Select(end => new EnderecoDTO(end)).ToList());
        
    }
}