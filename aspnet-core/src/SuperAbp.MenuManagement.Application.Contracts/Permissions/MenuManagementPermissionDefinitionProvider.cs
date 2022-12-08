using SuperAbp.MenuManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SuperAbp.MenuManagement.Permissions;

public class MenuManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MenuManagementPermissions.GroupName, L("Permission:MenuManagement"));

        var menus = myGroup.AddPermission(MenuManagementPermissions.Menus.Default, L("Permission:Menus"));
        menus.AddChild(MenuManagementPermissions.Menus.Management, L("Permission:Management"));
        menus.AddChild(MenuManagementPermissions.Menus.Create, L("Permission:Create"));
        menus.AddChild(MenuManagementPermissions.Menus.Update, L("Permission:Edit"));
        menus.AddChild(MenuManagementPermissions.Menus.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MenuManagementResource>(name);
    }
}
