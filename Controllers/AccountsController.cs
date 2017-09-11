using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Models;

namespace AuthenticationService.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Add([FromBody] Account accountModel )
        {
            return Json(accountModel);        
        }
        
        [HttpPost]
        public IActionResult Edit([FromBody] Account accountModel )
        {
            return Json(accountModel);        
        }

        [HttpPost("{id}")]
        public IActionResult Delete(int id )
        {
            return Ok();        
        }
    }
}