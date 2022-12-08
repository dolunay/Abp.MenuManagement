using SuperAbp.MenuManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace SuperAbp.MenuManagement.Blazor.Server.Host;

public abstract class MenuManagementComponentBase : AbpComponentBase
{
    protected MenuManagementComponentBase()
    {
        LocalizationResource = typeof(MenuManagementResource);
    }
}
