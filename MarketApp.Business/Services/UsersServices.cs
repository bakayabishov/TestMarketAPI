using AutoMapper;
using MarketApp.Business.Exceptions;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess.Entities;
using Microsoft.Extensions.Configuration;


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
    
    public async Task<int> AddUsersAsync(UserDto user) {
        if (await _uow.Users.IsAlreadyRegisteredAsync(user.Name))
        {
            throw new UserAlreadyExistException("The user with the same name already exist.", user.Name);

        }

        var entity = _mapper.Map<User>(user);
        await _uow.Users.InsertAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<UserDetailsDto> GetUserDetails(int id) 
    {
        return _mapper.Map<UserDetailsDto>(await _uow.Users.GetUser(id));
    }

    public async Task<List<UserDetailsDto>> GetAllAsync() {
        return _mapper.Map<List<UserDetailsDto>>(await _uow.Users.GetAllAsync());
    }
}
