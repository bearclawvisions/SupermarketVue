﻿using Microsoft.AspNetCore.Identity;
using Supermarket.Business.CustomExceptions;
using Supermarket.Business.Services.Interface;
using Supermarket.Domain.Dto.AppUser;
using Supermarket.Domain.Entities;
using System.Security.Claims;

namespace Supermarket.Business.Services.Implementation;

public class AppAppUserService : IAppUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AppAppUserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<string> CreateNewUser(RegisterDto newUser)
    {
        if (newUser.Password != newUser.ConfirmPassword)
            throw new Exception("Passwords do not match");
        
        if (!newUser.Terms)
            throw new Exception("Terms not accepted");
        
        var user = new AppUser
        {
            FirstName = newUser.FirstName.Trim(),
            LastName = newUser.LastName.Trim(),
            UserName = newUser.Email.Trim(),
            Email = newUser.Email.Trim(),
            CreatedOn = DateTime.UtcNow,
            LastLogin = DateTime.UtcNow,
        };
        var result = await _userManager.CreateAsync(user, newUser.Password);
        
        
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            throw new BusinessException(string.Join(Environment.NewLine, errors));
        }
        
        // var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        // var confirmationLink = Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, token }, Request.Scheme);

        // await _emailService.SendEmailAsync(user.Email, "Confirm your email", confirmationLink);

        return "Successfully registered";
    }

    public async Task<AppUser> GetUserForLogin(LoginDto userLogin)
    {
        var dbUser = await _userManager.FindByEmailAsync(userLogin.Email);
        if (dbUser == null)
            throw new Exception($"User {userLogin.Email} not found");
        
        var result = await _userManager.CheckPasswordAsync(dbUser, userLogin.Password);
        if (!result)
            throw new Exception("Password incorrect");

        return dbUser;
    }

    public async Task<AppUser?> AuthenticateUser(ClaimsPrincipal user)
    {
        var dbUser = await _userManager.GetUserAsync(user);
        
        return dbUser ?? null;
    }
}