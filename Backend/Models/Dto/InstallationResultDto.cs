using ToolsLibrary;

namespace Backend.Models.Dto
{
    public class InstallationResultDto
    {
        public List<InstallationStage> Results { get; set; }

    }

    public class InstallationStage
    {
        public string Name { get; set; } = string.Empty;
        public bool Successful { get; set; } = true;
        public string Data { get; set; } = string.Empty;
    }
}
