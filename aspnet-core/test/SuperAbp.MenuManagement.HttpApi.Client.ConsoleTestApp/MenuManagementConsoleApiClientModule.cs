using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SuperAbp.MenuManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SuperAbpMenuManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class MenuManagementConsoleApiClientModule : AbpModule
{

}
