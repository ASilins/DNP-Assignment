using Domain.Models;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserDto dto);
    Task<User> Login(UserDto dto);
}