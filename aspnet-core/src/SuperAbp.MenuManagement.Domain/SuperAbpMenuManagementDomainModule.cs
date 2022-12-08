using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SuperAbp.MenuManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SuperAbpMenuManagementDomainSharedModule)
)]
public class SuperAbpMenuManagementDomainModule : AbpModule
{

}
