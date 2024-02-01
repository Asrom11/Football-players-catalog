using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Models;
using _66BitTestovoe.Server.Models.Output;

namespace _66BitTestovoe.Server.Interfaces;

public interface IPlayerService
{
    public Task CreatePlayer(PlayerModelCreate playerModelCreate);
    public Task<bool> EditPlayer(PlayerEditModel playerEditModel);

    public Task<List<PlayerOutput>> GetAllPlayers();
}