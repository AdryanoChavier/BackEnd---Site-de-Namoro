using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Interfaces
{
    public interface IUsuarioRepository
    {
        void Update(AppUsuario usuario);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUsuario>> GetUsuarioAsync();
        Task<AppUsuario?> GetUsuarioByIdAsync(int id);
        Task<AppUsuario?> GetUsuarioByNomeAsync(string usuario_nome);
        Task<MembroDTO?> GetMembroAsync(string usuario_nome);
        Task<IEnumerable<MembroDTO>> GetMembrosAsync();

    }
}
