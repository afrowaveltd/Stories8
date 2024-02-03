namespace Backend.Models
{
  public class Article_Read
  {
    public int Id { get; set; }

    public int ArticleId { get; set; }

    public string? UserId { get; set; }

    public bool isAuthenticated { get; set; }

    public DateTime ReadAt { get; set; }

    public Article Article { get; set; }
    public UserModel User { get; set; }
  }
}