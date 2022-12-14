using App.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.DTOs;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserLogic userLogic;

    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(UserDto user)
    {
        try
        {
            User created = await userLogic.CreateAsync(user);
            return Created($"/users/{created.UserName}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("/login")]
    public async Task<ActionResult<User>> Login(UserDto dto)
    {
        try
        {
            User user = await userLogic.Login(dto);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}