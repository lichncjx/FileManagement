using System.Threading.Tasks;

namespace DHJ.FileManagement.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}