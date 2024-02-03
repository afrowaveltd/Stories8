using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class CategoryGroup
  {
    public int Id { get; set; }

    [Required]
    [DisplayName("Category group name")]
    public string GroupName { get; set; } = string.Empty;

    public List<Category> Categories { get; set; }
  }
}