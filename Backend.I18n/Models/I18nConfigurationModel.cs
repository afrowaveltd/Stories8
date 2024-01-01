namespace Backend.I18n.Models
{
  public class I18nConfigurationModel
  {
    public string TranslationsLocation { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "I18n");
    public string DefaultLanguage { get; set; } = "en";
    public List<LanguageModel> LanguagesSupported { get; set; } = new List<LanguageModel>();
  }
}