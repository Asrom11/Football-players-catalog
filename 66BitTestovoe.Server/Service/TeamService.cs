using _66BitTestovoe.Server.Dal.Interfaces;
using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Interfaces;
using _66BitTestovoe.Server.Models;
using _66BitTestovoe.Server.Models.Output;
using Medo;

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
    public async Task<TeamDal> CreateTeam(string teamName)
    {
        var teamId = new Uuid7().ToGuid();
        var newTeam = new TeamDal()
        {
            Id = teamId,
            TeamName = teamName,
            Players = []
        };
        await _teamRepository.CreateTeam(newTeam);

        return newTeam;
    }
}