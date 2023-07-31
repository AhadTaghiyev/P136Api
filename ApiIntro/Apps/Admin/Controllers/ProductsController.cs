using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIntro.Service.Dtos.Categories;
using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiIntro.Admin.Controllers
{
    [ApiController]
    [Authorize(Roles ="Admin,SuperAdmin")]
    [Route("api/admin/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return StatusCode(200, await _ProductService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ProductService.GetAsync(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductPostDto dto)
        {
            var resslt = await _ProductService.CreateAsync(dto);
            return StatusCode(resslt.StatusCode, resslt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ProductService.RemoveAsync(id);
            return StatusCode(result.StatusCode);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            var result = await _ProductService.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);
        }
    }
}

