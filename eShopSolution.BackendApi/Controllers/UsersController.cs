﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userServic;
        public UsersController(IUserService userService)
        {
            _userServic = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous] // Chua can login cung goi dc funtion nay
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userServic.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or Password is incorrect.");
            }
            return Ok(new { token = resultToken }); 
        }

        [HttpPost("register")]
        [AllowAnonymous] // Chua can login cung goi dc funtion nay
        public async Task<IActionResult> Register([FromForm]RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userServic.Register(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessfull.");
            }
            return Ok();
        }
    }
}
