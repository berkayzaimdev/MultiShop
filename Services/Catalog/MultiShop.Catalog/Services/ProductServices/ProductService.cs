﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllProductsAsync()
        {
            var values = await _productCollection.FindAsync(x => true);
            var valueList = await values.ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(valueList);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.FindAsync(x => x.Id == id);
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, value);
        }
    }
}