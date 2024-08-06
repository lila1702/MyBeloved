using System.ComponentModel.DataAnnotations;

namespace MyBeloved.API.Models;

public class Account
{
    [Key]
    public int Id { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid InvitePartnerLink { get; set; } = Guid.NewGuid();
}