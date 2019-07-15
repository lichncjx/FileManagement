using System.Threading.Tasks;
using DHJ.FileManagement.Security.Recaptcha;

namespace DHJ.FileManagement.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
