using Microsoft.AspNetCore.Components.Forms;

namespace Backend.Models.Dto
{
    public class AdministratorDto
    {
        public string? DisplayedName { get; set; } = "Lord of the server";
        public string FirstName { get; set; } = "Server";
        public string LastName { get; set; } = "Administrator";
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public IBrowserFile? Picture { get; set; }
        public string? PictureUrl { get; set; }
    }
}
