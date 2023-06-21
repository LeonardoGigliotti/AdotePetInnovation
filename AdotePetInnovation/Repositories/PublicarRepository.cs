using AdotePetInnovation.Models;
using MongoDB.Driver;

namespace AdotePetInnovation.Repositories;

public class PublicarRepository : IPublicarRepository
{
    private readonly IMongoCollection<Dog> _collection;

    public PublicarRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Dog>("dogs");
    }

    public async Task CreateAsync(Dog dog) =>
        await _collection.InsertOneAsync(dog);

    public async Task<List<Dog>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Dog> GetByIdAsync(string id) =>
        await _collection.Find(_ => _.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(Dog dog) =>
        await _collection.ReplaceOneAsync(x => x.Id == dog.Id, dog);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}
