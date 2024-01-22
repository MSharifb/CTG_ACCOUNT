namespace VistaGL.Administration
{
    using Serenity;
    using Serenity.Abstractions;

    public class TVLSecurityPermissionService : IPermissionService
    {

        public bool HasPermission(string permission)
        {
            if (Authorization.Username == "admin" || Authorization.Username == "administrator")
                return true;

            var user = (UserDefinition)Authorization.UserDefinition;

            if (user == null) return false;

            bool grant = user.Permissions?.Exists(e => e == permission.Replace(':', '/')) ?? false;
            return grant;
        }

    }
}