using Gerenciador_de_tarefas.Models;
using Gerenciador_de_tarefas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_de_tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            if(usuarios == null)
            {
                return Ok(new { message = "Ocorreu um erro interno!"});
            }
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody] UsuarioModel usuarioModel)
        {
            var usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Atualizar(UsuarioModel usuarioModel, int id)
        {
            var usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete]
        public async Task<ActionResult<UsuarioModel>> Deletar(int id)
        {
            var usuario = await _usuarioRepositorio.Deletar(id);
            return Ok(usuario);
        }
    }
}
