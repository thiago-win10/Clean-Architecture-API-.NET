using CatalogoCleanArchitecture.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoCleanArchitecture.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetCategorias();
        Task<CategoriaDTO> GetById(int? id);
        Task Add(CategoriaDTO categoriaDto);
        Task Update(CategoriaDTO categoriaDto);
        Task Remove(int? id);
    }
}
