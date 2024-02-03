using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Backend.Tools.Settings;

namespace Backend.Models
{
  public class UserModel : IdentityUser
  {
    [DisplayName("Public Name")]
    public string? DisplayedName { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [DisplayName("Registration Date")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime RegistrationTime { get; set; } = DateTime.UtcNow;

    [Required]
    [DisplayName("Birth Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
    public DateTime BirthDate { get; set; }

    [DisplayName("Last Seen")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime LastSeen { get; set; }

    public int? CountryId { get; set; }
    public string? DeactivatedByUser { get; set; }

    [DisplayName("Deactivated Since")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime DeactivatedSince { get; set; }

    [DisplayName("Deactivated Until")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
    public DateTime DeactivatedUntil { get; set; }

    public string? Reason { get; set; } = "";
    public string? PictureUrl { get; set; }

    public Gender Gender { get; set; } = Gender.Other;

    public string? Info { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? Microsoft { get; set; }

    public string? Google { get; set; }

    public int? ThemeId { get; set; }
    public string? NameFontColor { get; set; }

    public string? ChatFontColor { get; set; }

    public string? ChatBackgroundColor { get; set; }

    public bool? MessageNotification { get; set; }
    public bool? PrivateMessageNotification { get; set; }
    public bool? SystemMessageNotification { get; set; }

    [DisplayName("Who can see your email")]
    public AccessRights EmailPrivacy { get; set; } = AccessRights.Private;

    [DisplayName("Who can see your real name")]
    public AccessRights NamePrivacy { get; set; } = AccessRights.Private;

    [DisplayName("Who can see your friends list")]
    public AccessRights FrindsPrivacy { get; set; } = AccessRights.Public;

    [DisplayName("Who can see your phone number")]
    public AccessRights PhonePrivacy { get; set; } = AccessRights.Private;

    [DisplayName("Who can see your Social Media links")]
    public AccessRights SocialMediaLinksPrivacy { get; set; } = AccessRights.Public;

    [DisplayName("Who can see your country?")]
    public AccessRights CountryPrivacy { get; set; } = AccessRights.Public;

    [DisplayName("Who can see your birthday?")]
    public AccessRights BirthDatePrivacy { get; set; } = AccessRights.Public;

    [DisplayName("Who can see your picture?")]
    public AccessRights PictureFilePrivacy { get; set; } = AccessRights.Public;

    [DisplayName("Who can see you online?")]
    public AccessRights LastSeenPrivacy { get; set; } = AccessRights.Public;

    public Country Country { get; set; }

    public List<ActiveConnection> ActiveConnections { get; set; }
    public List<Administrator> Admins { get; set; }
    public List<Administrator> Activators { get; set; }
    public List<Administrator> Deaktivators { get; set; }
    public List<Article> Articles { get; set; }
    public List<Article> ArticlesBans { get; set; }
    public List<Article_Read> Article_Reads { get; set; }
    public List<Club> Clubs { get; set; }
    public List<Club_User> Club_Users { get; set; }
    public List<Collection> Collections { get; set; }
    public List<Critic> Critics { get; set; }
    public List<Friend> Friends { get; set; }
    public List<Friend> Befriended { get; set; }
    public List<ChatBan> ChatBansUsers { get; set; }
    public List<ChatBan> ChatBansAdmins { get; set; }
    public List<ChatElevated> ChatElevatedUsers { get; set; }
    public List<ChatMessage> ChatMessageSenders { get; set; }
    public List<ChatMessage> ChatMessageRecepient { get; set; }
    public List<Chatroom> Chatrooms { get; set; }
    public List<ChatroomAdmin> ChatroomAdmins { get; set; }
    public List<ChattingTime> ChattingTimes { get; set; }
    public List<Like> Likes { get; set; }
    public List<Message> Messages { get; set; }
    public List<MessageRecepient> MessageRecepients { get; set; }
    public List<Session> Sessions { get; set; }
    public List<SpamReport> SpamReportingUsers { get; set; }
    public List<SpamReport> SpamResolvingAdmins { get; set; }
    public List<Star> Stars { get; set; }
    public List<User_Favorite> user_Favorites { get; set; }
    public List<User_Favorite> user_FavoriteUsers { get; set; }
    public List<UsersInRoom> UsersInRoom { get; set; }
    public ApplicationSetup ApplicationSetup { get; set; }
  }
}