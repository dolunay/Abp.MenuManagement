using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.MenuManagement.Menus
{
    /// <summary>
    /// 列表
    /// </summary>
    public class MenuListDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Permission { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        public int Sort { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentName { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public bool Group { get; set; }

        /// <summary>
        /// 在Breadcrumb隐藏
        /// </summary>
        public bool HideInBreadcrumb { get; set; }

    }
}