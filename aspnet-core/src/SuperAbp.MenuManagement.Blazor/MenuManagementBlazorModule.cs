using Microsoft.Extensions.DependencyInjection;
using SuperAbp.MenuManagement.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace SuperAbp.MenuManagement.Blazor;

[DependsOn(
    typeof(MenuManagementApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class MenuManagementBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<MenuManagementBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<MenuManagementBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new MenuManagementMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(MenuManagementBlazorModule).Assembly);
        });
    }
}
