using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Article
  {
    public int Id { get; set; }

    public string AuthorId { get; set; }

    [Required]
    public string Title { get; set; }

    public string? Prologue { get; set; }

    [Required]
    public string Body { get; set; }

    public int SourceLanguageId { get; set; } = 0;
    public bool DoAutomaticTranslations { get; set; } = true;
    public string? Epilogue { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy HH:mm}")]
    [DisplayName("Article added at: ")]
    public DateTime ArticleAdded { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy HH:mm}")]
    [DisplayName("Article published at:")]
    public DateTime ArticlePublished { get; set; }

    public bool IsPublished { get; set; } = false;
    public bool IsBanned { get; set; } = false;
    public string? BannedById { get; set; }
    public int AgeRestrictionId { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy HH:mm}")]
    [DisplayName("Last Change:")]
    public DateTime LastChange { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy HH:mm}")]
    [DisplayName("First Published: ")]
    public DateTime FirstPublished { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy HH:mm}")]
    [DisplayName("Banned at")]
    public DateTime BannedAt { get; set; }

    public AgeRestriction AgeRestriction { get; set; }
    public UserModel Author { get; set; }
    public UserModel Banner { get; set; }
    public Language Language { get; set; }
    public List<ArticleTranslation> Translations { get; set; }

    public List<Article_Category> ArticleCategories { get; set; }
    public List<Article_Collection> Article_Collections { get; set; }
    public List<Article_Read> Article_Reads { get; set; }
    public List<Club_Article> Club_Articles { get; set; }
    public List<Critic> Critics { get; set; }
    public List<Like> Likes { get; set; }
    public List<Star> Stars { get; set; }
  }
}