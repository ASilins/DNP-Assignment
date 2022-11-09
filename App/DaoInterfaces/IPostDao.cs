using Domain.Models;

namespace App.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
}