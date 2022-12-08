using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace SuperAbp.MenuManagement;

[DependsOn(
    typeof(SuperAbpMenuManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SuperAbpMenuManagementApplicationContractsModule : AbpModule
{

}
