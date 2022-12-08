using SuperAbp.MenuManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SuperAbp.MenuManagement.Pages;

public abstract class MenuManagementPageModel : AbpPageModel
{
    protected MenuManagementPageModel()
    {
        LocalizationResourceType = typeof(MenuManagementResource);
    }
}
