using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _66BitTestovoe.Server.Controllers;

[ApiController]
[Route("team")]
public class TeamController: Controller
{
  private ITeamService _teamService;
  public TeamController(ITeamService teamService)
  {
    _teamService = teamService;
  }
  
  [HttpGet]
  public async Task<IActionResult> GetAllTeams()
  {
      var result = await _teamService.GetAllTeams();
      return Ok(result);
  }
}