using Logic;
using MarketmanWeb.ValidationFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketmanWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CelebritiesController : ControllerBase
    {
        private  readonly IManagerService managerService;

        public CelebritiesController(IManagerService managerService)
        {
            this.managerService = managerService;
        }

        [HttpGet]
        [Route("GetAllCelebritiesAsync")]
        public async Task<IActionResult> GetAllCelebritiesAsync()
        {
            IEnumerable<Celebrity> celebrities = await managerService.GetAllCelebritiesAsync();
            return Ok(celebrities);
        }
        [HttpPost]
        [Route("RemoveCelebrity")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RemoveCelebrityAsync(Celebrity celebrity)
        {
            IEnumerable<Celebrity> celebrities = await managerService.RemoveCelebrityAsync(celebrity);
            return Ok(celebrities);
        }

    }
}
