using Backend.I18n.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Text;

namespace Backend.I18n.Services
{
  public class JsonStringLocalizer : IStringLocalizer
  {
    private readonly IDistributedCache _cache;
    private readonly JsonSerializer _serializer = new JsonSerializer();
    private readonly I18nConfigurationModel _config;

    public JsonStringLocalizer(IDistributedCache cache, I18nConfigurationModel config)
    {
      _cache = cache;
      _config = config;
    }

    public LocalizedString this[string name]
    {
      get
      {
        string value = GetString(name);
        return new LocalizedString(name, value ?? name, value == null);
      }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
      get
      {
        LocalizedString actualValue = this[name];
        return !actualValue.ResourceNotFound
            ? new LocalizedString(name, string.Format(actualValue.Value, arguments), false)
            : actualValue;
      }
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
      string filePath = Path.Combine(_config.TranslationsLocation, Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower() + ".json");

      if (!File.Exists(filePath))
      {
        filePath = Path.Combine(_config.TranslationsLocation, "en.json");
        if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
      }

      using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var sReader = new StreamReader(stream))
      using (var reader = new JsonTextReader(sReader))
      {
        while (reader.Read())
        {
          if (reader.TokenType != JsonToken.PropertyName)
            continue;
          string key = (string)reader.Value;
          reader.Read();
          string value = _serializer.Deserialize<string>(reader);
          yield return new LocalizedString(key, value, false);
        }
      }
    }

    private string GetString(string key)
    {
      string filePath = Path.Combine(_config.TranslationsLocation, Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower()+".json");

      if (!File.Exists(filePath))
      {
        filePath = Path.Combine(_config.TranslationsLocation, "en.json");
      }
      string cacheKey = $"locale_{Thread.CurrentThread.CurrentCulture.Name}_{key}";
      string cacheValue = _cache.GetString(cacheKey);
      if (!string.IsNullOrEmpty(cacheValue)) return cacheValue;
      string result = GetValueFromJSON(key, filePath);
      if (!string.IsNullOrEmpty(result)) _cache.SetString(cacheKey, result);
      return result;
    }

    private string GetValueFromJSON(string propertyName, string filePath)
    {
      if (propertyName == null) return default;
      if (filePath == null) return default;
      using (var str = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var sReader = new StreamReader(str))
      using (var reader = new JsonTextReader(sReader))
      {
        while (reader.Read())
        {
          if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == propertyName)
          {
            reader.Read();
            return _serializer.Deserialize<string>(reader);
          }
        }

        return default;
      }
    }
  }
}