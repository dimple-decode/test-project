using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CRUD_Resonsive_Web_API.Interfaces;
using CRUD_Resonsive_Web_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using CRUD_Reponsive_Web_API.Utilities;

namespace CRUD_Reponsive_Web_API.Controllers
{
    [Route("api/{controller}")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("signIn")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody]SignInModel model)
        {
            if (ModelState.IsValid)
            {
                Account account;
                bool isValidCredentials = await _accountService.ValidateCredentials(model.Username, model.Password, out account);
                if (isValidCredentials)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Username),
                        new Claim("name", model.Username)
                    };

                    var authenticatedUser = TokenGenerator.GenerateUserToken(account, claims);
                    return Ok(authenticatedUser);
                }
            }

            return BadRequest();
        }

    }
}
