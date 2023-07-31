using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApiIntro.Client.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiIntro.Client.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string Endpoint= "http://localhost:5284";


        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            GetItems<CategoryGetDto> getItems = new GetItems<CategoryGetDto>();
            getItems.Items= new List<CategoryGetDto>();

            var json = await httpClient.GetStringAsync(Endpoint+ "/api/Categories");


            getItems = JsonConvert.DeserializeObject<GetItems<CategoryGetDto>>(json);

            return View(getItems.Items);
        }
    }
}

