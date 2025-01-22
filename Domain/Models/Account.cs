namespace Domain.Models;

public class Account
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string PasswordHash { get; set; } = string.Empty; // Za bezbednost čuvamo hash lozinke
    public string? PasswordResetToken { get; set; }
    public string? EmailConfirmationToken { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
    public string? MobileNumber { get; set; }

    // Navigacione veze
    public List<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
