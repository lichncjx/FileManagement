using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace DHJ.FileManagement.Net.Emailing
{
    public class FileManagementSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public FileManagementSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}