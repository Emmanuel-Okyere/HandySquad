using HandySquad.Models;

namespace HandySquad.Services.Interfaces;

public interface IOccupationService
{
    Task<IEnumerable<Occupation>> GetAllOccupationsAsync();
    Task<Occupation> GetOccupationByIdAsync(int id);
    Task CreateOccupationAsync(Occupation occupation);
    Task UpdateOccupationAsync(int id, Occupation updatedOccupation);
    Task DeleteOccupationAsync(int id);
}