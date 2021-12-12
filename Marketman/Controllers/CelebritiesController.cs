using Logic;
using Marketman.ValidationFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketman.Controllers
{
    [Route("api/[controller]")]
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
        [HttpDelete]
        [Route("RemoveCelebrity")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RemoveCelebrityAsync([FromBody] Celebrity celebrity)
        {
            IEnumerable<Celebrity> celebrities = await managerService.RemoveCelebrityAsync(celebrity);
            return Ok(celebrities);
        }

    }
}
