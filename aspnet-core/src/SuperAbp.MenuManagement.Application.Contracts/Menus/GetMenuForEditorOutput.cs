using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.MenuManagement.Menus
{
    /// <summary>
    /// 修改输出
    /// </summary>
    public class GetMenuForEditorOutput : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Permission { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        public string Key { get; set; }
        public int Sort { get; set; }
        public Guid? ParentId { get; set; }

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