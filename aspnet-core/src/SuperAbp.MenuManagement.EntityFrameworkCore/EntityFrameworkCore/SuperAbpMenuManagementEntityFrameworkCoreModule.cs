using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SuperAbp.MenuManagement.EntityFrameworkCore;

[DependsOn(
    typeof(SuperAbpMenuManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SuperAbpMenuManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MenuManagementDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
