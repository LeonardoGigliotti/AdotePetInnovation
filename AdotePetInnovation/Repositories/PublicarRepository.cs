using AdotePetInnovation.Models;
using MongoDB.Driver;

namespace AdotePetInnovation.Repositories;

public class PublicarRepository : IPublicarRepository
{
    private readonly IMongoCollection<Dog> _collection;
    private readonly IHttpContextAccessor _contextAccessor;

    public PublicarRepository(IMongoDatabase mongoDatabase, IHttpContextAccessor httpContextAccessor)
    {
        _collection = mongoDatabase.GetCollection<Dog>("dogs");
        _contextAccessor = httpContextAccessor;
    }

    public async Task CreateAsync(Dog dog)
    {
        dog.Usuario = _contextAccessor.HttpContext?.Session.GetString("userEmail");
        await _collection.InsertOneAsync(dog);
    }

    public async Task<List<Dog>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();
    public async Task<List<Dog>> GetByUserEmailAsync(string email) =>
       await _collection.Find(_ => _.Usuario == email).ToListAsync();

    public async Task<Dog> GetByIdAsync(string id) =>
        await _collection.Find(_ => _.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(Dog dog) =>
        await _collection.ReplaceOneAsync(x => x.Id == dog.Id, dog);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}
