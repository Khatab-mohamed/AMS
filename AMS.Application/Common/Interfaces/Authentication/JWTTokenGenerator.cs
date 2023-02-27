﻿using AMS.Domain.UserAggregate;

namespace AMS.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
