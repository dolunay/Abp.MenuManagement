using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SuperAbp.MenuManagement;

[DependsOn(
    typeof(SuperAbpMenuManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SuperAbpMenuManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SuperAbpMenuManagementApplicationContractsModule).Assembly,
            MenuManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SuperAbpMenuManagementHttpApiClientModule>();
        });

    }
}
