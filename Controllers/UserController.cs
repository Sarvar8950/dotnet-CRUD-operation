using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practiceApi.Data;
using practiceApi.DtoMapper;
using practiceApi.Dtos;

namespace practiceApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public UserController(ApplicationDbContext context) {
            _Context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> registerUser([FromBody] RegisterUserDto dataModal) {
            Console.WriteLine(dataModal.email);
            
            if (dataModal == null) {
                return BadRequest();
            }
            var data = dataModal.ToRegisterUser();

            var user = await _Context.User.AddAsync(data);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = data.id}, data.ToUserData());
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            var result = await _Context.User.FindAsync(id);
            if(result == null){
                return NotFound();
            }
            return Ok(result.ToUserData());
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginUserDto dataModal) {
            if (dataModal == null) {
                return BadRequest();
            }

            var user = await _Context.User.FirstOrDefaultAsync(x => x.email == dataModal.email);

            if (user == null) {
                return NotFound();
            }

            if(dataModal.password == user.password) {
                return Ok(user.ToUserData());
            }
            var response = new 
            {
                message = "User Not Found",
            };
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteById([FromQuery] int id) {
            if(id == 0) {
                return BadRequest();
            }

            var dataModal = await _Context.User.FirstOrDefaultAsync(x => x.id == id);
            if(dataModal == null) {
                return NotFound();
            }
            _Context.User.Remove(dataModal);
            await _Context.SaveChangesAsync();

            var response = new 
            {
                message = "User Deleted",
            };
            return Ok(response);
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> updateUser([FromBody] RegisterUserDto user) {

            var dataModal = await _Context.User.FirstOrDefaultAsync(x => x.email == user.email);

            if(dataModal == null) {
                return BadRequest(new CustomeResponseDto {
                status = "FAILURE",
                message = "User Not Found",
                data = null,
                statusCode = 404
                });
            }

            if(dataModal.password != user?.password) {
                return BadRequest(new CustomeResponseDto {
                status = "FAILURE",
                message = "Password Not Match",
                data = null,
                statusCode = 400
                });
            }

            dataModal.name = user.name;

            _Context.SaveChanges();

            // var res = CustomeResponseMapper.ToCustomeResponse("", "", 200, user);

            // return Ok(res);

            return Ok(new CustomeResponseDto {
                status = "SUCCESS",
                message = "User Updated",
                data = dataModal.ToUserData(),
                statusCode = 200
            });
        }
    
    }

}