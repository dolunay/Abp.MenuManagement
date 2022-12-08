using SuperAbp.MenuManagement.Localization;
using Volo.Abp.Application.Services;

namespace SuperAbp.MenuManagement;

public abstract class MenuManagementAppService : ApplicationService
{
    protected MenuManagementAppService()
    {
        LocalizationResource = typeof(MenuManagementResource);
        ObjectMapperContext = typeof(SuperAbpMenuManagementApplicationModule);
    }
}
