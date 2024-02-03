using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Club
  {
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name of the Club")]
    public string ClubName { get; set; }

    [Required]
    [Display(Name = "What is this club about?")]
    public string ClubDescription { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
    public DateTime ClubCreated { get; set; }

    public string OwnerId { get; set; }

    public bool isPublic { get; set; } = false;

    public bool isActive { get; set; } = false;
    public UserModel User { get; set; }
    public List<Club_Article> Club_Articles { get; set; }
    public List<Club_User> Club_Users { get; set; }
  }
}