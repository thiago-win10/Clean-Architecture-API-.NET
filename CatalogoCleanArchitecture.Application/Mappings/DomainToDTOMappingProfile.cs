using AutoMapper;
using CatalogoCleanArchitecture.Application.DTOs;
using CatalogoCleanArchitecture.Domain.Entities;

namespace CatalogoCleanArchitecture.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
