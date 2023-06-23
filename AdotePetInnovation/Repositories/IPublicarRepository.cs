using AdotePetInnovation.Models;

namespace AdotePetInnovation.Repositories;

public interface IPublicarRepository
{

    Task<List<Dog>> GetAllAsync();
    Task<List<Dog>> GetByUserEmailAsync(string email);
    Task<Dog> GetByIdAsync(string id);
    Task CreateAsync(Dog dog);
    Task UpdateAsync(Dog dog);
    Task DeleteAsync(string id);
}