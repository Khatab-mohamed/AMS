// Global using directives

global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using AMS.Application.Common.Interfaces;
global using AMS.Application.Common.Interfaces.Authentication;
global using AMS.Application.Common.Interfaces.Persistence;
global using AMS.Domain.Entities.Authentication;
global using AMS.Infrastructure.Authentication;
global using AMS.Infrastructure.Persistence;
global using AMS.Infrastructure.Services;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;