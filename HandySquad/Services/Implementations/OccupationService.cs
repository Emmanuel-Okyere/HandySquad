using HandySquad.Models;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Interfaces;

namespace HandySquad.Services.Implementations;

public class OccupationService:IOccupationService
{
    private readonly IOccupationRepository _occupationRepository;

    public OccupationService(IOccupationRepository occupationRepository)
    {
        _occupationRepository = occupationRepository;
    }

    public async  Task<IEnumerable<Occupation>> GetAllOccupationsAsync()
    {
        return await _occupationRepository.GetAllOccupationsAsync();
    }

    public async Task<Occupation> GetOccupationByIdAsync(int id)
    {
        return await _occupationRepository.GetOccupationByIdAsync(id);
    }

    public async Task CreateOccupationAsync(Occupation occupation)
    {
        if (occupation == null)
        {
            throw new ArgumentNullException(nameof(occupation));
        }

        await _occupationRepository.CreateOccupationAsync(occupation);
    }

    public async Task UpdateOccupationAsync(int id, Occupation updatedOccupation)
    {
        if (updatedOccupation==null)
        {
            throw new ArgumentNullException(nameof(updatedOccupation));
        }

        await _occupationRepository.UpdateOccupationAsync(id, updatedOccupation);
    }

    public async Task DeleteOccupationAsync(int id)
    {
        await _occupationRepository.DeleteOccupationAsync(id);
    }
}