namespace Backend.Models.Helpers
{
  public class SmtpTestResult
  {
    public List<SmtpTest> smtpTestResults { get; set; } = new List<SmtpTest>();
  }

  public class SmtpTest
  {
    public string TestName { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
        public SmtpTestStatus Result { get; set; } = SmtpTestStatus.Skipped;
  }

    public enum SmtpTestStatus
    {
        Pass,
        Fail,
        Skipped
    }
}