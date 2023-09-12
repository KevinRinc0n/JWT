namespace Dominio.Entities;

public class RefreshToken : BaseEntity
{
    public int UserId { get; set; } 
    public User User { get; set; }
    public string Token { get; set; } 
    public DateTime ExpirationDate { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpirationDate;
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public bool IsActive => Revoked == null && !IsExpired;
}
