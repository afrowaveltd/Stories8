namespace ToolsLibrary
{
  public class ApiResponse<T>
  {
    public T? Data { get; set; }
    public bool Error { get; set; } = false;
  }
}