namespace Backend.Models
{
  public class ArticleTranslation
  {
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int LanguageId { get; set; }
    public string Title { get; set; }
    public string? Prologue { get; set; }
    public string? Epilogue { get; set; }
    public string Body { get; set; }
    public Article Article { get; set; }
    public Language Language { get; set; }
  }
}