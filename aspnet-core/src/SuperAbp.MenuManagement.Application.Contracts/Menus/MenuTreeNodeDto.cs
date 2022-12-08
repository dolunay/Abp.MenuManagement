using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.MenuManagement.Menus
{
    public class MenuTreeNodeDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        /// <summary>
        /// 是否叶子
        /// </summary>
        public bool IsLeaf { get; set; }
    }
}