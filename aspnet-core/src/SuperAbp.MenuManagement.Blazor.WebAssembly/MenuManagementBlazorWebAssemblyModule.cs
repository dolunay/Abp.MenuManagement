using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace SuperAbp.MenuManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(MenuManagementBlazorModule),
    typeof(MenuManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class MenuManagementBlazorWebAssemblyModule : AbpModule
{

}
