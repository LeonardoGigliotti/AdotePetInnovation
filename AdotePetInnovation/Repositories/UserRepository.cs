using AdotePetInnovation.Models;
using MongoDB.Driver;

namespace AdotePetInnovation.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;

    public UserRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<User>("users");
    }

    public async Task<User> GetByEmailAsync(string email) =>
        await _collection.Find(_ => _.Email == email) .FirstOrDefaultAsync();

    public async Task CreateAsync(User user) =>
        await _collection.InsertOneAsync(user);    
}
