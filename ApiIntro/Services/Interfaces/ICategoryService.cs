using System;
using ApiIntro.Dtos.Categories;
using ApiIntro.Entities;
using ApiIntro.Responses;

namespace ApiIntro.Services.Interfaces
{
	public interface ICategoryService
	{
		public Task<ApiResponse> CreateAsync(CategoryPostDto dto);
		public Task<ApiResponse> GetAsync(int id);
		public Task<ApiResponse> GetAllAsync();
		public Task<ApiResponse> UpdateAsync(int id,CategoryUpdateDto dto);
		public Task<ApiResponse> RemoveAsync(int id);
    }
}

