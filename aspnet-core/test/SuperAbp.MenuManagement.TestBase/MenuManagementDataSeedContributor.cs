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
            var menu = new Menu(_menuTestData.MenuParentId)
            {
                Name = "Parent Name",
                Permission = "Parent Permission",
                Group = false,
                HideInBreadcrumb = false,
                Icon = "Parent Icon",
                ParentId = null,
                Route = "Parent Route",
                Sort = 999
            };
            await _menuRepository.InsertAsync(menu);
            await _menuRepository.InsertAsync(new Menu(_menuTestData.MenuId)
            {
                Parent = menu,
                Name = "Name",
                Permission = "Permission",
                Group = false,
                HideInBreadcrumb = false,
                Icon = "Icon",
                ParentId = null,
                Route = "Route",
                Sort = 999
            });
        }
    }
}