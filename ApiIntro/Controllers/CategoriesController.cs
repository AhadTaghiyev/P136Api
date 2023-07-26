using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIntro.Contexts;
using ApiIntro.Dtos.Categories;
using ApiIntro.Entities;
using ApiIntro.Repositories;
using ApiIntro.Repositories.Interfaces;
using ApiIntro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiIntro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return StatusCode(200,await _categoryService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetAsync(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CategoryPostDto dto)
        {
           var resslt= await _categoryService.CreateAsync(dto);
            return StatusCode(resslt.StatusCode,resslt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =await  _categoryService.RemoveAsync(id);
            return StatusCode(result.StatusCode);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody]CategoryUpdateDto dto)
        {
            var result =await _categoryService.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode,result);
        }
    }
}

