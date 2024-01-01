using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Backend.I18n.Middlewares
{
  public class I18nMiddleware : IMiddleware
  {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      string? cultureKey = context.Request.Headers["Accept-Language"];
      if (!string.IsNullOrEmpty(cultureKey))
      {
        if (CultureExists(cultureKey))
        {
          var culture = new CultureInfo(cultureKey);
          Thread.CurrentThread.CurrentCulture = culture;
          Thread.CurrentThread.CurrentUICulture = culture;
        }
      }
      else
      {
        var culture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
      }
      if (!string.IsNullOrEmpty(context.User.Identity.Name))
      {
      }
      await next(context);
    }

    private static bool CultureExists(string cultureName)
    {
      return CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture => string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase));
    }
  }
}