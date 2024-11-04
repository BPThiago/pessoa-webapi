using Microsoft.AspNetCore.Mvc;
using pessoa_webapi.Model.Usercase.EnderecoUsercase;
using PessoaWebApi.Model;
using PessoaWebApi.Model.DTO;

namespace PessoaWebApi.Controller
{
    [Route("/endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private IServiceProvider _serviceProvider;

        public EnderecoController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        [HttpGet("{id}")]
        public async Task<IResult> GetEndereco(int id)
        {
            var usercase = _serviceProvider.GetRequiredService<GetEnderecoUsercase>();
            return await usercase.Execute(id);
        }
        
        [HttpPost]
        public async Task<IResult> CreateEndereco(EnderecoDTO enderecoDto)
        {
            var usercase = _serviceProvider.GetRequiredService<CreateEnderecoUsercase>();
            return await usercase.Execute(enderecoDto);
        }
    }
}