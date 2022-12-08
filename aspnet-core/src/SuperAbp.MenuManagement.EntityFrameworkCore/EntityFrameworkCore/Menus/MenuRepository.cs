using SuperAbp.MenuManagement.EntityFrameworkCore;
using SuperAbp.MenuManagement.Menus;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.MenuManagement.EntityFrameworkCore.Menus
{
    public class MenuRepository : EfCoreRepository<IMenuManagementDbContext, Menu, Guid>, IMenuRepository
    {
        public MenuRepository(IDbContextProvider<IMenuManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}