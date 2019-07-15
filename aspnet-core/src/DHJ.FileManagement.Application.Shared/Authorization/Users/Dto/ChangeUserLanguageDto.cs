using System.ComponentModel.DataAnnotations;

namespace DHJ.FileManagement.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
