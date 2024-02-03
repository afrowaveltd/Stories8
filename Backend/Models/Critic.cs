using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Critic
  {
    public int Id { get; set; }
    public int ArticleId { get; set; }

    [DisplayName("Critic Added")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime CriticAdded { get; set; }

    public string UserId { get; set; }

    [Required]
    public string Message { get; set; }

    public bool Deleted { get; set; }
    public Article Article { get; set; }
    public UserModel User { get; set; }
  }
}