using Domain.DTOs;
using Domain.Models;

namespace App.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserDto user);
    Task<User> Login(UserDto user);
}