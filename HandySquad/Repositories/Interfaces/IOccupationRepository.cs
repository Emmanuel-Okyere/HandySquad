using HandySquad.Models;

namespace HandySquad.Repositories.Interfaces;

public interface IOccupationRepository
{
    Task<IEnumerable<Occupation>> GetAllOccupationsAsync();
    Task<Occupation> GetOccupationByIdAsync(int id);
    Task CreateOccupationAsync(Occupation occupation);
    Task UpdateOccupationAsync(int id, Occupation updatedOccupation);
    Task DeleteOccupationAsync(int id);
}