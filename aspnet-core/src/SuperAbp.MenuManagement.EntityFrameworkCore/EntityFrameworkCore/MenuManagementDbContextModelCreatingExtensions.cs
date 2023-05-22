using Microsoft.EntityFrameworkCore;
using SuperAbp.MenuManagement.Menus;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SuperAbp.MenuManagement.EntityFrameworkCore;

public static class MenuManagementDbContextModelCreatingExtensions
{
    public static void ConfigureMenuManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Menu>(b =>
        {
            b.ToTable(MenuManagementDbProperties.DbTablePrefix + nameof(Menu), MenuManagementDbProperties.DbSchema);
            b.Property(p => p.Name).IsRequired().HasMaxLength(MenuConsts.MaxNameLength);
            b.Property(p => p.Permission).HasMaxLength(MenuConsts.MaxPermissionLength);
            b.Property(p => p.Key).HasMaxLength(MenuConsts.MaxKeyLength);
            b.Property(p => p.Route).HasMaxLength(MenuConsts.MaxRouteLength);
            b.Property(p => p.Icon).HasMaxLength(MenuConsts.MaxIconLength);
            b.Property(p => p.Sort).IsRequired().HasDefaultValue(0);

            b.ConfigureFullAudited();
            b.ConfigureSoftDelete();
        });
    }
}