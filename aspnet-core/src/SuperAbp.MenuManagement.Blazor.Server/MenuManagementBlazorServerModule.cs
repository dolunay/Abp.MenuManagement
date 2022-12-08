using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace SuperAbp.MenuManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(MenuManagementBlazorModule)
    )]
public class MenuManagementBlazorServerModule : AbpModule
{

}
