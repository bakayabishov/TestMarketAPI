using AutoMapper;
using MarketApp.Business.Exceptions;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Exceptions;

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
            throw new UserAlreadyExistException("Пользователь с таким имененем уже есть в системе", user.Name);

        }

        var entity = _mapper.Map<User>(user);
        await _uow.Users.InsertAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<UserDetailsDto> GetUserDetails(int id) 
    {
        return _mapper.Map<UserDetailsDto>(await _uow.Users.GetByIdAsync(id));
    }

    public async Task<List<UserDetailsDto>> GetAllAsync() {
        return _mapper.Map<List<UserDetailsDto>>(await _uow.Users.GetAllAsync());
    }

    public async Task<int> AddSellerAsync(SellerDto seller, string manager) {
        var managerEntity = await _uow.Users.GetByLoginAsync(manager);
        if (await _uow.Users.IsAlreadyRegisteredAsync(seller.Name))
        {
            throw new UserAlreadyExistException("Пользователь с таким имененем уже есть в системе", seller.Name);

        }
        var entity = _mapper.Map<User>(seller);
        entity.ShopId = managerEntity.ShopId;
        entity.Role = Role.Seller;
        await _uow.Users.InsertAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Id;
    }

    public async Task RemoveSellersByIdAsync(string sellerName, string userName) {
        var user = await _uow.Users.GetByLoginAsync(sellerName);

        if (user is null)
        {
            throw new EntityNotFoundException("Пользователь не найден");
        }
        var currentUser = await _uow.Users.GetByLoginAsync(userName);

        if (currentUser.ShopId != user.ShopId)
        {
            throw new Exception("Вы можете удольять профили только своих сотрудников");
        }
        if (user.Role != Role.Seller)
        {
            throw new Exception("Вы можете удолять профили только продавцов");
        }


        await _uow.Users.DeleteSellersAsync(user.Id, currentUser.ShopId);
        await _uow.SaveChangesAsync();
    }
}