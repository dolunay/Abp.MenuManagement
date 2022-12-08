using Volo.Abp.Bundling;

namespace SuperAbp.MenuManagement.Blazor.Host;

public class MenuManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
