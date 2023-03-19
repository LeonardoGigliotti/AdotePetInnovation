using AdotePetInnovation.Models;

namespace AdotePetInnovation.Repositories;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task CreateAsync(User user);
}