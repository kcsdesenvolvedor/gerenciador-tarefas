using Gerenciador_de_tarefas.Data;
using Gerenciador_de_tarefas.Models;
using Gerenciador_de_tarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_tarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _sistemaTarefasDBContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _sistemaTarefasDBContext = sistemaTarefasDBContext; 
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _sistemaTarefasDBContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _sistemaTarefasDBContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            _sistemaTarefasDBContext.Usuarios.AddAsync(usuario);
            await _sistemaTarefasDBContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            var usuarioModel = await BuscarPorId(id);
            if (usuarioModel == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado!");
            }

            usuarioModel.Id = usuario.Id;
            usuarioModel.Nome = usuario.Nome;

            _sistemaTarefasDBContext.Usuarios.Update(usuarioModel);
            await _sistemaTarefasDBContext.SaveChangesAsync();

            return usuarioModel;
        }

        public async Task<UsuarioModel> Deletar(int id)
        {
            var usuarioModel = await BuscarPorId(id);
            if (usuarioModel == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado!");
            }

            _sistemaTarefasDBContext.Usuarios.Remove(usuarioModel);
            await _sistemaTarefasDBContext.SaveChangesAsync();

            return usuarioModel;
        }
    }
}
