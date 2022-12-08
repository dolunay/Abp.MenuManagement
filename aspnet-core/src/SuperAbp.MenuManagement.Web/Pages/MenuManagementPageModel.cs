using SuperAbp.MenuManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SuperAbp.MenuManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MenuManagementPageModel : AbpPageModel
{
    protected MenuManagementPageModel()
    {
        LocalizationResourceType = typeof(MenuManagementResource);
        ObjectMapperContext = typeof(SuperAbpMenuManagementWebModule);
    }
}
