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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }


        [HttpGet]
        public async Task<IEnumerable<Discount>> GetAll()
        {
            var obj = await _discountService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Discount> Get(int id)
        {
            var obj = await _discountService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Discount> Post(Discount obj)
        {
            return _discountService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Discount> Delete(int id)
        {
            return _discountService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Discount>> Update(int id, Discount obj)
        {
            return await _discountService.Update(id, obj);
        }
    }
}

