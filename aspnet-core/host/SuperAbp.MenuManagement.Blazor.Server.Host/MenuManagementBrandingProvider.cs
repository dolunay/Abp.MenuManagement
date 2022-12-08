using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SuperAbp.MenuManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class MenuManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MenuManagement";
}
