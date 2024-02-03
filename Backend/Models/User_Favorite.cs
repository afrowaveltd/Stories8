namespace Backend.Models
{
  public class User_Favorite
  {
    public int Id { get; set; }

    public string UserId { get; set; }

    public string AuthorId { get; set; }
    public UserModel User { get; set; }
    public UserModel Author { get; set; }
  }
}