using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoBase.Application.DTOs;
using ProjetoBase.Application.Interfaces;
using ProjetoBase.Domain.Entities;
using ProjetoBase.Domain.Interfaces;

namespace ProjetoBase.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email
            });
        }

        public async Task<UsuarioDTO> GetByIdAsync(int id)
        {
            var u = await _repository.GetByIdAsync(id);
            if (u == null) return null;
            return new UsuarioDTO { Id = u.Id, Nome = u.Nome, Email = u.Email };
        }

        public async Task AddAsync(UsuarioDTO dto)
        {
            var u = new Usuario { Nome = dto.Nome, Email = dto.Email };
            await _repository.AddAsync(u);
        }

        public async Task UpdateAsync(UsuarioDTO dto)
        {
            var u = new Usuario { Id = dto.Id, Nome = dto.Nome, Email = dto.Email };
            await _repository.UpdateAsync(u);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
