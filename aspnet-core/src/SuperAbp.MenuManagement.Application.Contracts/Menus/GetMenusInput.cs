using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.MenuManagement.Menus
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetMenusInput : PagedAndSortedResultRequestDto
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
    }
}