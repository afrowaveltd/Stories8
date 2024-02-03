namespace Backend.Models
{
  public class AgeRestriction
  {
    public int Id { get; set; }
    public int MinimalAge { get; set; } = 0;
    public List<Article> Articles { get; set; }
  }
}