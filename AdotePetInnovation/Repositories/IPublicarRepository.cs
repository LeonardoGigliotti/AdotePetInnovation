using AdotePetInnovation.Models;

namespace AdotePetInnovation.Repositories;

public interface IPublicarRepository
{
    Task CreateAsync(Dog dog);
}