using HandySquad.Data;
using HandySquad.Models;
using HandySquad.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandySquad.Repositories.Implementations;

public class OccupationRepository:IOccupationRepository
{
    private readonly DataContext _dataContext;

    public OccupationRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Occupation>> GetAllOccupationsAsync()
    {
        return await _dataContext.Occupations.ToListAsync();
    }

    public async Task<Occupation> GetOccupationByIdAsync(int id)
    {
        return await _dataContext.Occupations.FindAsync(id);
    }

    public async Task CreateOccupationAsync(Occupation occupation)
    {
        if (occupation == null)
        {
            throw new ArgumentNullException(nameof(occupation));
        }

        _dataContext.Occupations.Add(occupation);
        await _dataContext.SaveChangesAsync();
    }

    public async  Task UpdateOccupationAsync(int id, Occupation updatedOccupation)
    {
        var occupation = await _dataContext.Occupations.FindAsync(id);
        if (occupation == null)
        {
            throw new Exception($"Occupation With {id} Not Found");
        }
        //update occupation
        occupation.JobTitle = updatedOccupation.JobTitle;
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteOccupationAsync(int id)
    {
        var occupation = await _dataContext.Occupations.FindAsync(id);
        if (occupation == null)
        {
            throw new Exception($"Occupation not found");
        }
        _dataContext.Occupations.Remove(occupation);
        await _dataContext.SaveChangesAsync();
    }
}

