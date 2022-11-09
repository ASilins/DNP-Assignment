using App.DaoInterfaces;
using App.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace App.Logic;

public class PostLogic : IPostLogic
{

    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto newPost)
    {
        User? user = await userDao.GetByUsernameAsync(newPost.UserName);

        if (user == null)
        {
            throw new Exception($"User with username {newPost.UserName} does not exist!");
        }

        ValidateDto(newPost);
        Post post = new Post(user, newPost.Title, newPost.Body);
        Post created = await postDao.CreateAsync(post);

        return created;
    }

    private void ValidateDto(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
            throw new Exception("Title cannot be empty!");

        if (string.IsNullOrEmpty(dto.Body))
            throw new Exception("Body cannot be empty!");
    }
}