using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using DHJ.FileManagement.Authorization.Users;
using DHJ.FileManagement.MultiTenancy;

namespace DHJ.FileManagement.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}