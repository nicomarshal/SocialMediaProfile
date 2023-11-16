﻿using SocialMediaProfile.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IEducationRepository : IGenericRepository<Education>
    {
        Task<IEnumerable<Education>> GetAllByAliasAsync(string alias);
    }
}