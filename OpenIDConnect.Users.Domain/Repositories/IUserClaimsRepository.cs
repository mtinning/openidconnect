﻿using OpenIDConnect.Users.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenIDConnect.Users.Domain.Repositories
{
    public interface IUserClaimsRepository
    {
        Task<IEnumerable<Claim>> GetUserClaims(string username);

        Task<IEnumerable<Claim>> GetUserClaimsOfType(string username, string claimType);

        Task AddClaimsToUser(string username, IEnumerable<Claim> claims);
    }
}