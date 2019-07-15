namespace DHJ.FileManagement.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}