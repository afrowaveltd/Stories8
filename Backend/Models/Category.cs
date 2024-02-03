using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Category
  {
    public int Id { get; set; }

    [Required]
    [DisplayName("Category")]
    public string CategoryName { get; set; } = string.Empty;

    public int CategoryGroupId { get; set; }

    public CategoryGroup CategoryGroup { get; set; }

    public List<Article_Category> ArticleCategories { get; set; }
    public List<Collection_Categories> CollectionCategories { get; set; }
  }
}