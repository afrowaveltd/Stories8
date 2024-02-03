namespace Backend.Models.Helpers
{
  public class Report
  {
    public ReportTypes Type { get; set; }
    public string Text { get; set; }
  }

  public enum ReportTypes
  {
    info,
    success,
    error,
    warning,
    notice
  }

  public enum TestResults
  {
    Passed,
    Failed,
    Missed
  }
}