﻿using AutoMapper;
using CatalogoCleanArchitecture.Application.DTOs;
using CatalogoCleanArchitecture.Application.Interfaces;
using CatalogoCleanArchitecture.Domain.Entities;
using CatalogoCleanArchitecture.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoCleanArchitecture.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriesEntity);
        }

        public async Task<CategoriaDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoryEntity);
        }

        public async Task Add(CategoriaDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoryDto);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task Update(CategoriaDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoryDto);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoryEntity);
        }
    }
}
