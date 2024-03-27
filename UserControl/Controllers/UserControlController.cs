using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserControl.Application.DTO;
using UserControl.Application.Interfaces;
using UserControl.Domain.Entities;

namespace UserControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControlController : ControllerBase
    {
        private readonly IUserControlAppService _userAppService;

        public UserControlController(IUserControlAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO user)
        {
            try
            {
                 await _userAppService.CreateUserValidationAsync(user);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userAppService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,UserEditDTO dto)
        {
            try
            {
                dto.Id = id;
                await _userAppService.UpdateUserValidationAsync(dto);
                return Ok("User updating successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                 await _userAppService.DeleteAsync(id);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetId(Guid id)
        {
            try
            {
                var user = await _userAppService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
