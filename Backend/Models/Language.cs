using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Language
  {
    [Key]
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Flag { get; set; } = string.Empty;
    public List<Article> Articles { get; set; }
    public List<ArticleTranslation> Translations { get; set; }
  }
}