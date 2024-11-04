using PessoaWebApi.Model.DTO;

namespace PessoaWebApi.Model.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }
    }
}