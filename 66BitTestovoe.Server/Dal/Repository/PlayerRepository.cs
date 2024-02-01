using _66BitTestovoe.Server.Dal.Interfaces;
using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace _66BitTestovoe.Server.Dal.Repository;

public class PlayerRepository: IPlayerRepository
{
    private ApplicationContextDb _applicationContextDb;

    public PlayerRepository(ApplicationContextDb applicationContextDb)
    {
        _applicationContextDb = applicationContextDb;
    }
    
    public async Task CreatePlayer(PlayerDal playerDal)
    {
        var dbSet = _applicationContextDb.PlayerDbSet;
        await dbSet.AddAsync(playerDal);
        await _applicationContextDb.SaveChangesAsync();
    }

    public async Task EditPlayer(PlayerDal playerDal)
    {
        _applicationContextDb.PlayerDbSet.Update(playerDal);
        await _applicationContextDb.SaveChangesAsync();
    }

    public  async Task<PlayerDal> GetById(Guid guid)
    {
        var player = await _applicationContextDb.PlayerDbSet.FindAsync(guid);
        return player;
    }

    public async Task<List<PlayerOutput>> GetAllPlayers()
    {
        var players = await _applicationContextDb.PlayerDbSet
            .Include(p => p.Team)
            .Select(p => new PlayerOutput()
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Gender = p.Gender,
                Country = p.Country,
                BirthDate = p.BirthDate,
                TeamName = p.Team.TeamName,
                PlayerId = p.Id
            })
            .ToListAsync();
        return players;
    }
}