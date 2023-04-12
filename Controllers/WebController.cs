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
using ProjectJunior.Services.Interfaces;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : Controller
    {
        private readonly IWebService _webService;

        public WebController(IWebService webService)
        {
            _webService = webService;
        }


        [HttpGet]
        public async Task<IEnumerable<Web>> GetAll()
        {
            var webs = await _webService.GetAll();
            return webs.Data;
        }

        [HttpGet("{id}")]
        public async Task<Web> GetWeb(int id)
        {
            var web = await _webService.Get(id);
            return web.Data;
        }

        [HttpPost]
        public IBaseResponse<Web> Post(Web web)
        {
            return _webService.Add(web);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Web> Delete(int id)
        {
            return _webService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Web>> Update(int id, Web obj)
        {
            return await _webService.Update(id, obj);
        }
    }    
}

