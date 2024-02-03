namespace Backend.Models
{
  public class Like
  {
    public int Id { get; set; }

    public string UserId { get; set; }
    public int ArticleId { get; set; }
    public UserModel User { get; set; }
    public Article Article { get; set; }
  }
}