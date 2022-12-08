using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SuperAbp.MenuManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class MenuManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MenuManagementInstallerModule>();
        });
    }
}
