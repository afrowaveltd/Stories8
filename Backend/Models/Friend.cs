using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Friend
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string FriendId { get; set; }
    public RequestStatus Status { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime RequestTime { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime AnsweringAction { get; set; }

    public UserModel User { get; set; }
    public UserModel UserFriend { get; set; }
  }

  public enum RequestStatus
  {
    Confirmed,
    Declined,
    Blocked
  };
}