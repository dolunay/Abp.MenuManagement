using Volo.Abp.Reflection;

namespace SuperAbp.MenuManagement.Permissions;

public class MenuManagementPermissions
{
    public const string GroupName = "SuperAbpMenuManagement";

    public static class Menus
    {
        public const string Default = GroupName + ".Menu";
        public const string Management = Default + ".Management";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(MenuManagementPermissions));
    }
}
