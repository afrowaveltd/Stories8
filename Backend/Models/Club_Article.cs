namespace Backend.Models
{
  public class Club_Article
  {
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int ClubId { get; set; }

    public Article Article { get; set; }
    public Club Club { get; set; }
  }
}