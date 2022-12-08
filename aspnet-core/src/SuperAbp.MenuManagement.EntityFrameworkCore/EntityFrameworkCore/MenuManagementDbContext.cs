using Microsoft.EntityFrameworkCore;
using SuperAbp.MenuManagement.Menus;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.MenuManagement.EntityFrameworkCore;

[ConnectionStringName(MenuManagementDbProperties.ConnectionStringName)]
public class MenuManagementDbContext : AbpDbContext<MenuManagementDbContext>, IMenuManagementDbContext
{
    public DbSet<Menu> Menus { get; set; }

    public MenuManagementDbContext(DbContextOptions<MenuManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureMenuManagement();
    }
}
