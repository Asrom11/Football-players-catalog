﻿using _66BitTestovoe.Server.Dal.Models;
using _66BitTestovoe.Server.Models.Output;

namespace _66BitTestovoe.Server.Interfaces;

public interface ITeamService
{
    public Task<AllTeams> GetAllTeams();
    public Task<TeamDal> CreateTeam(string teamName);
}