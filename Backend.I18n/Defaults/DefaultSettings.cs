using Backend.I18n.Models;

namespace Backend.I18n.Defaults
{
  public class DefaultSettings
  {
    public I18nConfigurationModel GetDefaultConfiguration()
    {
      List<LanguageModel> LibreLanguages = new List<LanguageModel>();
      I18nConfigurationModel DefaultConfiguration = new I18nConfigurationModel();
      LibreLanguages.Add(new LanguageModel() { Code = "en", Name="English", Flag="https://flagcdn.com/w320/gb.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "ar", Name="Arabic", Flag="https://flagcdn.com/w320/ae.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "az", Name="Azerbaijani", Flag="https://flagcdn.com/w320/az.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "zh", Name="Chinese", Flag="https://flagcdn.com/w320/cn.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "cs", Name="Czech", Flag="https://flagcdn.com/w320/cz.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "nl", Name="Dutch", Flag="https://flagcdn.com/w320/nl.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "eo", Name="Esperanto", Flag="https://www.fotw.info/images/q/qy-eo.gif" });
      LibreLanguages.Add(new LanguageModel() { Code = "fi", Name="Finnish", Flag="https://flagcdn.com/w320/fi.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "fr", Name="French", Flag="https://flagcdn.com/w320/fr.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "de", Name="German", Flag="https://flagcdn.com/w320/de.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "el", Name="Greek", Flag="https://flagcdn.com/w320/gr.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "hi", Name="Hindi", Flag="https://flagcdn.com/w320/in.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "hu", Name="Hungarian", Flag="https://flagcdn.com/w320/hu.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "id", Name="Indonesian", Flag="https://flagcdn.com/w320/id.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "ga", Name="Irish", Flag="https://flagcdn.com/w320/ie.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "it", Name="Italian", Flag="https://flagcdn.com/w320/it.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "ja", Name="Japanese", Flag="https://flagcdn.com/w320/jp.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "ko", Name="Korean", Flag="https://flagcdn.com/w320/kr.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "fa", Name="Persian", Flag="https://flagcdn.com/w320/ir.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "pl", Name="Polish", Flag="https://flagcdn.com/w320/pl.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "pt", Name="Portuguese", Flag="https://flagcdn.com/w320/pt.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "ru", Name="Russian", Flag="https://flagcdn.com/w320/ru.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "sk", Name="Slovak", Flag="https://flagcdn.com/w320/sk.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "es", Name="Spanish", Flag="https://flagcdn.com/w320/es.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "sv", Name="Sweish", Flag="https://flagcdn.com/w320/se.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "tr", Name="Turkish", Flag="https://flagcdn.com/w320/tr.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "uk", Name="Ukrainian", Flag="https://flagcdn.com/w320/ua.png" });
      LibreLanguages.Add(new LanguageModel() { Code = "vi", Name="Vietnamese", Flag="https://flagcdn.com/w320/vn.png" });

      DefaultConfiguration.LanguagesSupported = LibreLanguages;
      DefaultConfiguration.DefaultLanguage = "en";
      DefaultConfiguration.TranslationsLocation = Directory.GetCurrentDirectory();

      return DefaultConfiguration;
    }
  }
}