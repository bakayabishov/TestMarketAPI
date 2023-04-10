using AutoMapper;
using MarketApp.Business.Exceptions;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Services;

public class UsersServices : IUsersServices
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public UsersServices(IMapper mapper, IUnitOfWork uow)
    {
        _mapper = mapper;
        _uow = uow;
    }
    
    public async Task AddUsersAsync(UserDto user)
    {
        if (await _uow.Users.IsAlreadyRegisteredAsync(user.Name))
        {
            throw new UserAlreadyExistException("The student cannot be found.", user.Name);

        }

        await _uow.Users.InsertAsync(_mapper.Map<User>(user));
        await _uow.SaveChangesAsync();
    }

    public async Task<UserDetailsDto> GetUserDetails(string name) 
    {
        return _mapper.Map<UserDetailsDto>(await _uow.Users.GetUser(name));
    }
}