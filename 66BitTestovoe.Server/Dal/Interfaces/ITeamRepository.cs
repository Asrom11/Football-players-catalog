using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Models.Output;

namespace _66BitTestovoe.Server.Dal.Interfaces;

public interface ITeamRepository
{
    public Task<AllTeams> GetAllTeams();
    public Task<TeamDal?> GetByName(string name);
    public Task CreateTeam(TeamDal teamDal);
}