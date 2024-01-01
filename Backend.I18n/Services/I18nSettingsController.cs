using Backend.I18n.Defaults;
using Backend.I18n.Models;
using Newtonsoft.Json;

namespace Backend.I18n.Services
{
  public class I18nSettingsController
  {
    /**
     * Working with own JSON file, which it creates
     * during the first run
     *  Load Settings,
     *  Save Settings,
     *  Monitor File Size
     */
    private static readonly string programDirectory = Directory.GetCurrentDirectory();
    private readonly string settingsFile = Path.Combine(programDirectory, "i18n.json");

    public async Task<I18nConfigurationModel> Load()
    {
      I18nConfigurationModel config = new I18nConfigurationModel();
      if (!ConfigurationFileExists())
      {
        await CreateDefaultConfigurationFile();
      }
      try
      {
        string json = await File.ReadAllTextAsync(settingsFile);
        return JsonConvert.DeserializeObject<I18nConfigurationModel>(json);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return null;
      }
    }

    public async Task Save(I18nConfigurationModel settings)
    {
      try
      {
        string settingsJson = JsonConvert.SerializeObject(settings);
        await File.WriteAllTextAsync(settingsFile, settingsJson);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private bool ConfigurationFileExists()
    {
      return File.Exists(Path.Combine(programDirectory, "i18n.json"));
    }

    private async Task CreateDefaultConfigurationFile()
    {
      I18nConfigurationModel settings = new DefaultSettings().GetDefaultConfiguration();
      string settingsJson = JsonConvert.SerializeObject(settings);
      try
      {
        await File.WriteAllTextAsync(settingsFile, settingsJson);
        return;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}