using SuperAbp.MenuManagement.EntityFrameworkCore;
using SuperAbp.MenuManagement.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.MenuManagement.EntityFrameworkCore.Menus
{
    public class MenuRepository : EfCoreRepository<IMenuManagementDbContext, Menu, Guid>, IMenuRepository
    {
        public MenuRepository(IDbContextProvider<IMenuManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<bool> AnyByParentIdAsync(Guid parentId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.AnyAsync(a => a.ParentId == parentId);
        }

        public override async Task<IQueryable<Menu>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).Include(m => m.Parent);
        }
    }
}