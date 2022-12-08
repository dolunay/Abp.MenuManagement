using SuperAbp.MenuManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SuperAbp.MenuManagement;

public abstract class MenuManagementController : AbpControllerBase
{
    protected MenuManagementController()
    {
        LocalizationResource = typeof(MenuManagementResource);
    }
}
