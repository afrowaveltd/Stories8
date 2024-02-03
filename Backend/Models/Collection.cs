using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Collection
  {
    public int Id { get; set; }

    [Required]
    [DisplayName("Collection")]
    public string CollectionName { get; set; }

    [DisplayName("Collection description")]
    public string CollectionDescription { get; set; } = "";

    public string UserId { get; set; }

    public UserModel User { get; set; }

    public List<Article_Collection> Article_Collections { get; set; }
    public List<Collection_Categories> Collection_Categories { get; set; }
  }
}