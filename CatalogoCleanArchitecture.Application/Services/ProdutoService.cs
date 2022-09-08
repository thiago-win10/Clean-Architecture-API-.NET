﻿using AutoMapper;
using CatalogoCleanArchitecture.Application.DTOs;
using CatalogoCleanArchitecture.Application.Interfaces;
using CatalogoCleanArchitecture.Domain.Entities;
using CatalogoCleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoCleanArchitecture.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _productRepository;

        private readonly IMapper _mapper;
        public ProdutoService(IMapper mapper, IProdutoRepository productRepository)
        {
            _productRepository = productRepository ??
                 throw new ArgumentNullException(nameof(productRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var productsEntity = await _productRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(productsEntity);
        }

        public async Task<ProdutoDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(productEntity);
        }

        public async Task Add(ProdutoDTO productDto)
        {
            var productEntity = _mapper.Map<Produto>(productDto);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task Update(ProdutoDTO productDto)
        {

            var productEntity = _mapper.Map<Produto>(productDto);
            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);
        }
    }
}
