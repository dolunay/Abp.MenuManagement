using Localization.Resources.AbpUi;
using SuperAbp.MenuManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace SuperAbp.MenuManagement;

[DependsOn(
    typeof(SuperAbpMenuManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SuperAbpMenuManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SuperAbpMenuManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MenuManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
