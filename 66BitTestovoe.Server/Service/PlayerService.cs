
using _66BitTestovoe.Server.Dal.Interfaces;
using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Interfaces;
using _66BitTestovoe.Server.Models;
using _66BitTestovoe.Server.Models.Output;
using Medo;

namespace _66BitTestovoe.Server.Service;

public class PlayerService: IPlayerService
{
    private IPlayerRepository _playerRepository;
    private ITeamRepository _teamRepository;
    private ITeamService _teamService;
    public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository, ITeamService teamService)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _teamService = teamService;
    }

    public async Task CreatePlayer(PlayerModelCreate playerModelCreate)
    {
        var playerId = new Uuid7().ToGuid();
        var team = await _teamRepository.GetByName(playerModelCreate.TeamName);
        if (team is null)
        {
            team = await _teamService.CreateTeam(playerModelCreate.TeamName);
        }
        
        var player = new PlayerDal
        {
            Id = playerId,
            FirstName = playerModelCreate.FirstName,
            LastName = playerModelCreate.LastName,
            Gender = playerModelCreate.Gender,
            Country = playerModelCreate.Country,
            BirthDate = playerModelCreate.BirthDate,
            TeamID = team.Id,
            Team = team
        };
        
        await _playerRepository.CreatePlayer(player);
    }
    
    public async Task<bool> EditPlayer(PlayerEditModel playerEditModel)
    {
        var currentPlayer = await _playerRepository.GetById(playerEditModel.PlayerId);
        if (currentPlayer is null)
        {
            return false;
        }
        
        var team = await _teamRepository.GetByName(playerEditModel.TeamName);

        if (team is null)
        {
            team = await _teamService.CreateTeam(playerEditModel.TeamName);
        }
        
        currentPlayer.FirstName = playerEditModel.FirstName;
        currentPlayer.LastName = playerEditModel.LastName;
        currentPlayer.Gender = playerEditModel.Gender;
        currentPlayer.BirthDate = playerEditModel.BirthDate;
        currentPlayer.Country = playerEditModel.Country;
        currentPlayer.TeamID = team.Id;
        currentPlayer.Team = team;
        
        await _playerRepository.EditPlayer(currentPlayer);
        return true;
    }
    
    public Task<List<PlayerOutput>> GetAllPlayers()
    {
       return _playerRepository.GetAllPlayers();
    }
}