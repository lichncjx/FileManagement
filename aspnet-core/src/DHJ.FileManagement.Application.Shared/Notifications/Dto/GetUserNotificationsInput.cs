using Abp.Notifications;
using DHJ.FileManagement.Dto;

namespace DHJ.FileManagement.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}