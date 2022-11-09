using Domain.DTOs;
using Domain.Models;

namespace App.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(User user);
    Task<User> Login(UserLoginDto user);
}