using Domain.DTOs;
using Domain.Models;

namespace App.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto newPost);
    Task<IEnumerable<Post>> GetAsync(PostSearchParameterDto dto);
}