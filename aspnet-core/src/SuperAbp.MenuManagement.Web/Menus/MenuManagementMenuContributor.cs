using System.Threading.Tasks;
using SuperAbp.MenuManagement.Localization;
using SuperAbp.MenuManagement.Permissions;
using Volo.Abp.UI.Navigation;

namespace SuperAbp.MenuManagement.Web.Menus;

public class MenuManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        if (await context.IsGrantedAsync(MenuManagementPermissions.Menus.Default))
        {
            var l = context.GetLocalizer<MenuManagementResource>();

            context.Menu.GetAdministration().AddItem(new ApplicationMenuItem(MenuManagementMenus.Menu, displayName: l["Menu"], "~/Menus", icon: "fa fa-globe"));
        }
    }
}
