using System.Collections.Generic;
using DHJ.FileManagement.Authorization.Users.Dto;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}