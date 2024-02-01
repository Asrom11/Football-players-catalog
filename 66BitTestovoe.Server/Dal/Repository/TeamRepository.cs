using _66BitTestovoe.Server.Dal.Interfaces;
using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Models.Output;
using Microsoft.EntityFrameworkCore;

namespace _66BitTestovoe.Server.Dal.Repository;

public class TeamRepository: ITeamRepository
{
    private ApplicationContextDb _applicationContextDb;

    public TeamRepository(ApplicationContextDb applicationContextDb)
    {
        _applicationContextDb = applicationContextDb;
    }
    public async Task<AllTeams> GetAllTeams()
    {
        var dbSet = _applicationContextDb.TeamDbSet;
        var teams = await dbSet
            .Select(t => t.TeamName)
            .ToListAsync();
        return new AllTeams()
        {
            Teams = teams
        };
    }

    public async Task CreateTeam(TeamDal teamDal)
    {
        await _applicationContextDb.TeamDbSet.AddAsync(teamDal);
        await _applicationContextDb.SaveChangesAsync();
    }
    public async Task<TeamDal?> GetByName(string name)
    {
        return await  _applicationContextDb.TeamDbSet
            .FirstOrDefaultAsync(t => t.TeamName == name);
    }
}