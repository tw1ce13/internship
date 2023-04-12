using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectJunior.Models;
using ProjectJunior.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Services.Response;
using ProjectJunior.Data.Implementations;

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : Controller
    {

        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }


        [HttpGet]
        public async Task<IEnumerable<Delivery>> GetAll()
        {
            var obj = await _deliveryService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Delivery> Get(int id)
        {
            var obj = await _deliveryService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Delivery> Post(Delivery obj)
        {
            return _deliveryService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Delivery> Delete(int id)
        {
            return _deliveryService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Delivery>> Update(int id, Delivery obj)
        {
            return await _deliveryService.Update(id, obj);
        }
    }
}

