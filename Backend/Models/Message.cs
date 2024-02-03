using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Message
  {
    public int Id { get; set; }

    public string SenderId { get; set; }

    [Required]
    public string Subject { get; set; }

    [Required]
    [DisplayName("Message")]
    public string MessageText { get; set; }

    [DisplayName("Sent at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime SentTime { get; set; }

    public bool Deleted { get; set; } = false;
    public UserModel User { get; set; }

    public List<MessageRecepient> Recepients { get; set; }
    public List<SpamReport> SpamReports { get; set; }
  }
}