using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIntro.Service.Dtos.Categories;
using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiIntro.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}

