using CRUD_Reponsive_Web_API.Interfaces;
using CRUD_Reponsive_Web_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUD_Reponsive_Web_API.Controllers
{
    [Route("api/{controller}")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("GetUsers")]
        [HttpGet]
      
        public async Task<IActionResult> Get()
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var response = await _userService.GetUser(id);
            return Ok(response);
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.AddUser(model);
                return Ok(response);
            }

            return BadRequest();
        }


        [Route("EditUser/{id}")]
        [HttpPut]
        public async Task<IActionResult> EditUser([FromRoute] string id, [FromBody] UserModel user)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.EditUser(id, user);
                return Ok(response);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _userService.DeleteUser(id);
            return Ok(response);
        }


    }
}
