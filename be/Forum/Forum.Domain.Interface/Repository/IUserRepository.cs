﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.User.Data;

namespace Forum.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        Task<List<UserBasicDto>> GetUserListAsync();
        Task<UserDto> GetUserAsync(string userId);
    }
}
