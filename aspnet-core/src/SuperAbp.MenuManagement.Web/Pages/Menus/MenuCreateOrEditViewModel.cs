using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace SuperAbp.MenuManagement.Web.Pages.Menus
{
    public class MenuCreateOrEditViewModel
    {
        [Required]
        [Placeholder("Name")]
        public string Name { get; set; }

        [Placeholder("Permission")]
        public string Permission { get; set; }

        [Placeholder("Icon")]
        public string Icon { get; set; }

        [Placeholder("Route")]
        public string Route { get; set; }

        [Placeholder("Sort")]
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
