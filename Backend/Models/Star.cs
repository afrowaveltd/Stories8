namespace Backend.Models
{
  public class Star
  {
    public int Id { get; set; }

    public int ArticleId { get; set; }

    public string UserId { get; set; }

    public int Stars { get; set; }
    public Article Article { get; set; }
    public UserModel User { get; set; }
  }
}