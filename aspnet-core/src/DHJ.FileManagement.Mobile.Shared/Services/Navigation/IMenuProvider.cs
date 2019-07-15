using System.Collections.Generic;
using MvvmHelpers;
using DHJ.FileManagement.Models.NavigationMenu;

namespace DHJ.FileManagement.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}