using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Models;
using System.ComponentModel.DataAnnotations;
using AuthenticationService.Common.Attributes;
using AuthenticationService.Data;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationService.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<Account> _userManager;
        // private readonly SignInManager<Account> _signInManager;
        private ApplicationDbContext _dbContext;

        public AccountsController(ApplicationDbContext dbContext,UserManager<Account> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            // _signInManager = signInManager;
        }
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
        public async Task<IActionResult> Add([FromBody][Required] AccountSettings accountModel )
        {
            if (!ModelState.IsValid) //Here i have a breakpoint!
            {
                return BadRequest(new
                {
                    code = 400,
                    message = ModelState.Values.First().Errors.First().ErrorMessage
                });
            }


            Account user = new Account { UserName = accountModel.Name};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, accountModel.Password);
            // _dbContext.Accounts.Add(new Account(){ 
            //     UserName = accountModel.Name,
            //     Pa = accountModel.Password,
            //     Role = new Role(){ Name = accountModel.Role}  });
            
            //ASYNC!!!
            //_dbContext.SaveChanges();

            return Json(accountModel);        
        }
        
        [HttpPost]
        public IActionResult Edit([FromBody] AccountSettings accountModel )
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