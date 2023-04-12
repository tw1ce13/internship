using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectJunior.Data;
using ProjectJunior.Models;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Services.Response;
using ProjectJunior.Data.Implementations;

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }


        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetAll()
        {
            var obj = await _recipeService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Recipe> Get(int id)
        {
            var obj = await _recipeService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Recipe> Post(Recipe obj)
        {
            return _recipeService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Recipe> Delete(int id)
        {
            return _recipeService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Recipe>> Update(int id, Recipe obj)
        {
            return await _recipeService.Update(id, obj);
        }
    }
}

