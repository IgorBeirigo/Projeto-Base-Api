using ProjetoBase.Domain.Entities;
using ProjetoBase.Application.DTOs;


namespace ProjetoBase.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> GetByIdAsync(int id);
        Task AddAsync(UsuarioDTO usuarioDto);
        Task UpdateAsync(UsuarioDTO usuarioDto);
        Task DeleteAsync(int id);
    }
}

