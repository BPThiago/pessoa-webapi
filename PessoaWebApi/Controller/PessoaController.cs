using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PessoaWebApi.Model;
using PessoaWebApi.Model.DTO;
using PessoaWebApi.Model.Usercase.PessoaUsercase;

namespace PessoaWebApi.Controller
{
    [Route("/")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IServiceProvider _serviceProvider;

        public PessoaController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IResult> GetAllPessoas()
        {
            var usercase = _serviceProvider.GetRequiredService<GetAllPessoasUsercase>();
            return await usercase.Execute();
        }
        
        [HttpGet("{id}")]
        public async Task<IResult> GetPessoa(int id)
        {
            var usercase = _serviceProvider.GetRequiredService<GetPessoaUsercase>();
            return await usercase.Execute(id);
        }

        [HttpPost]
        public async Task<IResult> CreatePessoa(PessoaDTO pessoaDto)
        {
            var usercase = _serviceProvider.GetRequiredService<CreatePessoaUsercase>();
            return await usercase.Execute(pessoaDto);
        }
    }
}