using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBeloved.API.Models;

public class Partner
{
    [Key]
    public int Id { get; set; }
    public string NickName { get; set; }
    public int PartnerId { get; set; }
    public bool HasAccount { get; set; } = false;
    // This User Account, so the Partner wouldn't have "view-only" access anymore
    public Account? UserAccount { get; set; }

}