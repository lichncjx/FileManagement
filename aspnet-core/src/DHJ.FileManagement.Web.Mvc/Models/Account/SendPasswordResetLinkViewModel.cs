using System.ComponentModel.DataAnnotations;

namespace DHJ.FileManagement.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}