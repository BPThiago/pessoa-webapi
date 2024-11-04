using Microsoft.EntityFrameworkCore;
using PessoaWebApi.Model.Domain;

namespace PessoaWebApi.Model
{
    public class PessoaDb : DbContext
    {
        public PessoaDb(DbContextOptions<PessoaDb> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas => Set<Pessoa>();
        public DbSet<Endereco> Enderecos => Set<Endereco>();
    }
}