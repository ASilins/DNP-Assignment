using App.DaoInterfaces;
using App.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace App.Logic;

public class UserLogic : IUserLogic
{

    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserDto user)
    {
        User? existing = await userDao.GetByUsernameAsync(user.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");


        User created = await userDao.CreateAsync(
            new User
            {
                UserName = user.UserName,
                Password = user.Password
            }
        );

        return created;
    }

    public async Task<User> GetByUsername(string userName)
    {
        User? existing = await userDao.GetByUsernameAsync(userName);

        if (existing == null)
            throw new Exception("User not found");

        return existing;
    }

    public async Task<User> Login(UserDto user)
    {
        User? existing = await userDao.GetByUsernameAsync(user.UserName);

        if (existing != null)
        {
            if (existing.Password.Equals(user.Password))
            {
                return existing;
            }
            else
            {
                throw new Exception("Password is incorrect!");
            }
        }
        else
        {
            throw new Exception("Username is incorrect!");
        }
    }
}