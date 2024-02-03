namespace Backend.Models
{
  public class Club_User
  {
    public int Id { get; set; }

    public string UserId { get; set; }

    public int ClubId { get; set; }

    public UserModel User { get; set; }
    public Club Club { get; set; }
  }
}