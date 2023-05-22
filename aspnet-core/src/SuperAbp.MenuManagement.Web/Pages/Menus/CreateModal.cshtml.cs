using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperAbp.MenuManagement.Menus;
using SuperAbp.MenuManagement.Permissions;

namespace SuperAbp.MenuManagement.Web.Pages.Menus
{
    public class CreateOrEditorModalModel : MenuManagementPageModel
    {
        private readonly IMenuAppService _menuAppService;
        private readonly IAuthorizationService _authorization;

        public CreateOrEditorModalModel(IMenuAppService menuAppService, IAuthorizationService authorization)
        {
            _menuAppService = menuAppService;
            _authorization = authorization;
        }

        [BindProperty]
        public MenuCreateViewModel Menu { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            if (!await _authorization.IsGrantedAsync(MenuManagementPermissions.Menus.Create))
            {
                return RedirectToPage("/Pages/Menus/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<MenuCreateViewModel, MenuCreateDto>(Menu);
            await _menuAppService.CreateAsync(dto);
            return NoContent();
        }
    }

    public class MenuCreateViewModel : MenuCreateOrEditViewModel
    {
    }
}