using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class UsuarioRepository(DataContext context) : IUsuarioRepository
    {
        public async Task<AppUsuario?> GetUsuarioByIdAsync(int id)
        {
            return await context.Usuario.FindAsync(id);
        }
        public async Task<AppUsuario?> GetUsuarioByNomeAsync(string usuario_nome)
        {
            return await context.Usuario.Include(x => x.Fotos).SingleOrDefaultAsync(x => x.usuario_nome == usuario_nome);
        }
        public async Task<IEnumerable<AppUsuario>> GetUsuarioAsync()
        {
            return await context.Usuario.Include(x => x.Fotos).ToListAsync();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
        public void Update(AppUsuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
        }
    }
}
