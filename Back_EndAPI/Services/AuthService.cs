using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using Back_EndAPI.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _hasher = new();

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    // LOGIN
    public async Task<string?> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (user == null)
            return null;

        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed)
            return null;

        // Simple token for now (you can replace with JWT later)
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }

    // REGISTER (optional but useful)
    public async Task<int> RegisterAsync(string username, string password)
    {
        var exists = await _context.Users.AnyAsync(u => u.Username == username);
        if (exists)
            throw new InvalidOperationException("Username already exists.");

        var user = new User
        {
            Username = username,
            PasswordHash = _hasher.HashPassword(null!, password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }
}
