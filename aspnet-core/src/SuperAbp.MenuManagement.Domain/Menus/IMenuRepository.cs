using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.MenuManagement.Menus
{
    public interface IMenuRepository : IRepository<Menu, Guid>
    {
        Task<bool> AnyByParentIdAsync(Guid parentId);
    }
}