using AutoMapper;
using MarketApp.API.Models;
using MarketApp.Business.Interfaces;
using MarketApp.DataAccess.Repositories.Interfaces;
using TestAPIMarket.Data.Entities;
using TestAPIMarket.Data.Repositories.Interfaces;

namespace MarketApp.Business.Services;

public class UsersServices : IUsersServices
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;


    public UsersServices(IUsersRepository usersRepository, IMapper mapper, IUnitOfWork uow)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _uow = uow;
    }
}