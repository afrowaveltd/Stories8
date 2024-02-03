namespace Backend.Models
{
  public class MessageRecepient
  {
    public int Id { get; set; }
    public int MessageId { get; set; }
    public string RecepientId { get; set; } = "";
    public bool WasRead { get; set; } = false;
    public DateTime ReadTime { get; set; }
    public bool WasDeleted { get; set; } = false;
    public bool DontShowInBin { get; set; } = false;

    public Message Message { get; set; }
    public UserModel Recepient { get; set; }
  }
}