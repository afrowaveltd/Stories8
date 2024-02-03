namespace Backend.Models
{
  public class Article_Category
  {
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int CategoryId { get; set; }
    public Article Article { get; set; }
    public Category Category { get; set; }
  }
}