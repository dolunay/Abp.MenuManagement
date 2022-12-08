using Volo.Abp.Modularity;

namespace SuperAbp.MenuManagement;

[DependsOn(
    typeof(SuperAbpMenuManagementApplicationModule),
    typeof(MenuManagementDomainTestModule)
    )]
public class MenuManagementApplicationTestModule : AbpModule
{

}
