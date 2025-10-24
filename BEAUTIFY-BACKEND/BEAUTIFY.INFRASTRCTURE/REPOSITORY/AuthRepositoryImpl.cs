using BEAUTIFY.APPLICATION.DTO;
using BEAUTIFY.APPLICATION.INTERFACE;
using BEAUTIFY.DOMAIN.MODELS;
using BEAUTIFY.INFRASTRCTURE.APP_DB_CONTEXT;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
public class AuthRepositoryImpl : IAuthRepository
{

    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ITokenRepository _tokenRepo;

    public AuthRepositoryImpl(UserManager<AppUser> userManager, IConfiguration configuration, ITokenRepository tokenRepo)
    {
        _userManager = userManager;
        _configuration = configuration;
        _tokenRepo = tokenRepo;
    }

    public async Task<AuthResultDto> RegisterAsync(RegisterModel model)
    {
        var user = new AppUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            Lastname = model.LastName,
            DateOfBirth = model.DateOfBirth,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "System"
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return new AuthResultDto
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        var token = _tokenRepo.GenerateAccessToken(user);
        var refreshToken = _tokenRepo.GenerateRefreshToken();

        // Save refresh token
        user.RefreshTokens = new List<RefreshToken>
        {
            new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                CreatedDate = DateTime.UtcNow,
                UserId = user.Id
            }
        };
        await _userManager.UpdateAsync(user);

        return new AuthResultDto
        {
            Success = true,
            Token = token,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResultDto> LoginAsync(LoginDto model)
    {
        // Validate user existence
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return new AuthResultDto
            {
                Success = false,
                Errors = new[] { "Invalid credentials" }
            };
        }

        // Check if user is locked
        if (await _userManager.IsLockedOutAsync(user))
        {
            return new AuthResultDto
            {
                Success = false,
                Errors = new[] { "User is locked out" }
            };
        }

        // Generate tokens
        var token = _tokenRepo.GenerateAccessToken(user);
        var refreshToken = _tokenRepo.GenerateRefreshToken();

        // ✅ Ensure refresh token list is initialized
        if (user.RefreshTokens == null)
        {
            user.RefreshTokens = new List<RefreshToken>();
        }

        // Add refresh token entry
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiryDate = DateTime.UtcNow.AddDays(7),
            CreatedDate = DateTime.UtcNow,
            UserId = user.Id
        });

        // Save changes to the database
        await _userManager.UpdateAsync(user);

        // Return tokens to client
        return new AuthResultDto
        {
            Success = true,
            Token = token,
            RefreshToken = refreshToken
        };
    }


    public async Task<bool> IsLockedOutAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user != null && await _userManager.IsLockedOutAsync(user);
    }

    public Task<bool> ValidateCaptchaAsync(string captchaResponse)
    {
        // Stub for CAPTCHA validation
        return Task.FromResult(true);
    }
}

