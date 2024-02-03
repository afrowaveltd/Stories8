namespace Backend.Models
{
  public class SpamReport
  {
    public int Id { get; set; }
    public int MessageId { get; set; }

    public DateTime ReportedAt { get; set; }

    public string ReportedById { get; set; }

    public string AdminUserId { get; set; }
    public bool WasSpam { get; set; }

    public Message Message { get; set; }
    public UserModel User { get; set; }
    public UserModel Admin { get; set; }
  }
}