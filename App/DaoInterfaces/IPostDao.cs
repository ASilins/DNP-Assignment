using Domain.DTOs;
using Domain.Models;

namespace App.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(PostSearchParameterDto dto);
}