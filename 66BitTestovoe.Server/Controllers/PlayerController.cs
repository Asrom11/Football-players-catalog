using _66BitTestovoe.Server.Interfaces;
using _66BitTestovoe.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace _66BitTestovoe.Server.Controllers;

[ApiController]
[Route("player")]
public class PlayerController: Controller
{
    private IPlayerService _playerService;
    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddPlayer([FromBody] PlayerModelCreate playerModelCreate)
    {
        await _playerService.CreatePlayer(playerModelCreate);
        return Created();
    }

    [HttpPut("edit")]
    public async Task<IActionResult> EditPlayer([FromBody] PlayerEditModel playerEditModel)
    {
        var result = await _playerService.EditPlayer(playerEditModel);

        return result is false ? NotFound("Player is not found") : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var result = await _playerService.GetAllPlayers();
        return Ok(result);
    }
}