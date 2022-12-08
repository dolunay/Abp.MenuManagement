using System.Threading.Tasks;
using SuperAbp.MenuManagement.Menus;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace SuperAbp.MenuManagement;

public class MenuManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly MenuTestData _menuTestData;
    private readonly ICurrentTenant _currentTenant;
    private readonly IMenuRepository _menuRepository;

    public MenuManagementDataSeedContributor(
        ICurrentTenant currentTenant, IMenuRepository menuRepository, MenuTestData menuTestData)
    {
        _currentTenant = currentTenant;
        _menuRepository = menuRepository;
        _menuTestData = menuTestData;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Instead of returning the Task.CompletedTask, you can insert your test data
         * at this point!
         */

        using (_currentTenant.Change(context?.TenantId))
        {
            await _menuRepository.InsertAsync(new Menu(_menuTestData.MenuId)
            {
                Name = "名称",
                Permission = "权限",
                Group = false,
                HideInBreadcrumb = false,
                Icon = "图标",
                ParentId = null,
                Route = "路由",
                Sort = 999
            });
        }
    }
}
