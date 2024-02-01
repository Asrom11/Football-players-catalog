using _66BitTestovoe.Server.Dal.Interfaces;
using _66BitTestovoe.Server.Interfaces;
using _66BitTestovoe.Server.Models.Output;

namespace _66BitTestovoe.Server.Service;

public class TeamService: ITeamService
{
    private ITeamRepository _teamRepository;
    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<AllTeams> GetAllTeams()
    {
        var result = await _teamRepository.GetAllTeams();
        return result;
    }
}