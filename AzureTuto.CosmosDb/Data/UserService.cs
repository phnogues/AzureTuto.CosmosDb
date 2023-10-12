using AzureTuto.CosmosDb.Infrastructure.Persistence;
using AzureTuto.CosmosDb.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureTuto.CosmosDb.Data;

public class UserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetUserstAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> AddUserAsync(User entity)
    {
        var newUser = _dbContext.Users.Add(entity);
        await _dbContext.SaveChangesAsync();

        return newUser.Entity;
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = _dbContext.Users.Find(userId);
        if (user is not null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
