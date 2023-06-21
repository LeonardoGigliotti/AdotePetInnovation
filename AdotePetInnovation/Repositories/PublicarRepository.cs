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


}
