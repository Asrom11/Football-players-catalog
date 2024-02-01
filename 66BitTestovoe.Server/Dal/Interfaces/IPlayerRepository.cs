using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Models;
using _66BitTestovoe.Server.Models.Output;

namespace _66BitTestovoe.Server.Dal.Interfaces;

public interface IPlayerRepository
{
    public Task CreatePlayer(PlayerDal playerDal);
    public Task EditPlayer(PlayerDal playerDal);
    public Task<PlayerDal> GetById(Guid guid);
    public Task<List<PlayerOutput>> GetAllPlayers();
}