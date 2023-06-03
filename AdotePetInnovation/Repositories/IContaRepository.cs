using AdotePetInnovation.Models;

namespace AdotePetInnovation.Repositories;

public interface IContaRepository
{
    Task CreateAsync(DoadorEAdotante doadorEAdotante);
}