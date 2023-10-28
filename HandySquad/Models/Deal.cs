using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandySquad.Models;
[Table("deal")]
public class Deal
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double AmountTobePaid { get; set; }
    public bool AcceptedByArtisan { get; set; }
    public bool AcceptedByClient { get; set; }
    public User? Client { get; set; }
    public User? Artisan { get; set; }
    public int? ClientId { get; set; }
    public int? ArtisanId { get; set; }
    public bool WorkStatusUpdateByClient { get; set; }
    public bool WorkStatusUpdateByArtisan { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ExpectedEndDateByClient { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
}