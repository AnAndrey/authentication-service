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
using AuthenticationService.Common.Extensions;
using Microsoft.EntityFrameworkCore;

//ToDO
// Validate model using AttributeValidation
// Return detailed error
// need to change roles and password
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
        public IActionResult Get()
        {
            
            var accounts = _userManager.Users.Include(r => r.Role).Select(x => x.ToAccountView());
            return Json(accounts); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var account = await _userManager.Users.Include(r => r.Role).FirstOrDefaultAsync(x => x.Id == id);
            return Json(account.ToAccountView()); 
        }

        [HttpPost]
        //[ValidateModel]
        //  X-XSRF-TOKEN
        public async Task<IActionResult> Add([FromBody][Required] AccountSettings accountModel )
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(new
                {
                    code = 400,
                    message = ModelState.Values.First().Errors.First().ErrorMessage
                });
            }
            
            var result = await _userManager.CreateAsync(accountModel.ToAccount(), accountModel.Password);

            return Json(accountModel);        
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] AccountView accountModel )
        {
            // if (!ModelState.IsValid) 
            // {
            //     return BadRequest(new
            //     {
            //         code = 400,
            //         message = ModelState.Values.First().Errors.First().ErrorMessage
            //     });
            // }
            var account = _userManager.FindByIdAsync(accountModel.Id).Result;
            account.UserName = accountModel.Name;

            var result = await _userManager.UpdateAsync(account);
            if(result.Succeeded)
            {
                var newAccount = await _userManager.Users.Include(r => r.Role).FirstOrDefaultAsync(x => x.Id == accountModel.Id);
                return Json( newAccount.ToAccountView());
            }   
            return BadRequest();        
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(string id )
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var account = await _userManager.FindByIdAsync(id);
            if(account != null)
            {
                var result = await _userManager.DeleteAsync(account);
                if(result.Succeeded)
                return Ok();
            }
            return BadRequest();        
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}