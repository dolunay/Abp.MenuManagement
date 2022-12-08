using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.MenuManagement.EntityFrameworkCore;

public class MenuManagementHttpApiHostMigrationsDbContext : AbpDbContext<MenuManagementHttpApiHostMigrationsDbContext>
{
    public MenuManagementHttpApiHostMigrationsDbContext(DbContextOptions<MenuManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureMenuManagement();
    }
}
