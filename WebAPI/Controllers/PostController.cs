using App.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Domain.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{

    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody] PostCreationDto dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Created("Post created", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? ownername, [FromQuery] string? title, [FromQuery] int? id)
    {
        try
        {
            PostSearchParameterDto dto = new(ownername, title, id);
            var posts = await postLogic.GetAsync(dto);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e);
        }
    }
}