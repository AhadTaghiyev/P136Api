using System;
using ApiIntro.Core.Entities;
using ApiIntro.Core.Repositories;
using ApiIntro.Core.Repositories.Interfaces;
using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Extentions;
using ApiIntro.Service.Responses;
using ApiIntro.Service.Services.Interfaces;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ApiIntro.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env, ICategoryRepository categoryRepository, IHttpContextAccessor http)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
            _categoryRepository = categoryRepository;
            _http = http;
        }

        public async Task<ApiResponse> CreateAsync(ProductPostDto dto)
        {
            if(! await _categoryRepository.IsExsist(x => x.Id == dto.CategoryId))
            {
                return new ApiResponse { StatusCode = 404,Description="Category Id is invalid" };
            }
            Product product = _mapper.Map<Product>(dto);
            product.Image = dto.File.SaveFile(_env.WebRootPath,"assets/images");
            product.ImageUrl = _http.HttpContext.Request.Scheme + "://" + _http.HttpContext.Request.Host+$"/assets/images/{product.Image}";
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
            return new ApiResponse { StatusCode = 201 };
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var query = await _productRepository.GetAllAsync(x => !x.IsDeleted, "Category");

            IEnumerable<ProductGetDto> productGetDtos = await
                query.Select(x => new ProductGetDto { Image = x.Image, ImageUrl=x.ImageUrl,CategoryId = x.CategoryId, Name = x.Name, Price = x.Price
                ,CategoryName=x.Category.Name}).ToListAsync();
            return new ApiResponse { StatusCode = 200, Items = productGetDtos };
        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            Product Product = await _productRepository.GetAsync(x=>!x.IsDeleted&&x.Id==id, "Category");

            if (Product == null)
            {
                return new ApiResponse { StatusCode = 404,Description="Not found" };
            }

            ProductGetDto productGet = _mapper.Map<ProductGetDto>(Product);
            productGet.CategoryName = Product.Category.Name;
            return new ApiResponse { StatusCode = 200, Items = productGet };
        }

        public async Task<ApiResponse> RemoveAsync(int id)
        {
            Product Product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (Product == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Not found" };
            }

            Product.IsDeleted = true;
            await _productRepository.Update(Product);
            await _productRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }

        public async Task<ApiResponse> UpdateAsync(int id, ProductUpdateDto dto)
        {
            Product Product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (Product == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Not found" };
            }

            Product.Name = dto.Name;
            Product.Price = dto.Price;
            Product.CategoryId = dto.CategoryId;
            Product.Image = dto.File == null ? Product.Image : dto.File.SaveFile(_env.WebRootPath, "assets/images");
            await _productRepository.Update(Product);
            await _productRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }
    }
}

