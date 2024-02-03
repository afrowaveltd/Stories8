using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Country
  {
    public int Id { get; set; }

    [Required]
    public string CountryName { get; set; }

    [MaxLength(512)]
    public string? FlagFilePath { get; set; } = "";

    public int PhonePrefix { get; set; }
    public int? Timezone { get; set; } = 0;

    public List<UserModel> Users { get; set; }
  }
}