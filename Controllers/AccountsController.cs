using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Models;
using System.ComponentModel.DataAnnotations;
using AuthenticationService.Common.Attributes;

namespace AuthenticationService.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountsController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        //[ValidateModel]
        //  X-XSRF-TOKEN
        public IActionResult Add([FromBody][Required] AccountR accountModel )
        {
            if (!ModelState.IsValid) //Here i have a breakpoint!
            {
                return BadRequest(new
                {
                    code = 400,
                    message = ModelState.Values.First().Errors.First().ErrorMessage
                });
            }
            return Json(accountModel);        
        }
        
        [HttpPost]
        public IActionResult Edit([FromBody] AccountR accountModel )
        {
            return Json(accountModel);        
        }

        [HttpPost("{id}")]
        public IActionResult Delete(int id )
        {
            return Ok();        
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}