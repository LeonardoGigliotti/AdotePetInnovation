using AdotePetInnovation.Models;
using MongoDB.Driver;

namespace AdotePetInnovation.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly IMongoCollection<DoadorEAdotante> _collection;

    public ContaRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<DoadorEAdotante>("doadoreadotante");
    }

    public async Task CreateAsync(DoadorEAdotante doadorEAdotante) =>
        await _collection.InsertOneAsync(doadorEAdotante);    
}
