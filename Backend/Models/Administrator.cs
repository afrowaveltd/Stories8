using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Administrator
  {
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    public string ActivatedById { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy HH:mm}")]
    [DisplayName("Activated Time:")]
    public DateTime ActivatedAt { get; set; }

    [StringLength(128)]
    [DisplayName("Reason for deactivation:")]
    [MaxLength(256, ErrorMessage = "Maximum 256 characters")]
    public string? DeactivationReason { get; set; } = "";

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy HH:mm}")]
    [DisplayName("Deactivation Time:")]
    public DateTime DeactivatedAt { get; set; }

    public string? DeactivatedById { get; set; }
    public bool IsActive { get; set; } = true;

    public UserModel? User { get; set; }
    public UserModel? Activator { get; set; }
    public UserModel? Deactivator { get; set; }
  }
}