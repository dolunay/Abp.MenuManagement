using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperAbp.MenuManagement.Menus;
using Volo.Abp.ObjectMapping;

namespace SuperAbp.MenuManagement.Web.Pages.Menus;

public class EditModalModel : MenuManagementPageModel
{
    private  readonly IMenuAppService _menuAppService;

    public EditModalModel(IMenuAppService menuAppService)
    {
        _menuAppService = menuAppService;
    }

    public MenuEditViewModel Menu { get; set; }

    public async Task OnGetAsync(Guid id)
    {
        var dto = await _menuAppService.GetEditorAsync(id);
        Menu = ObjectMapper.Map<GetMenuForEditorOutput, MenuEditViewModel>(dto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<MenuEditViewModel, MenuUpdateDto>(Menu);
        await _menuAppService.UpdateAsync(Menu.Id, dto);
        return NoContent();
    }
}

public class MenuEditViewModel : MenuCreateOrEditViewModel
{
    public Guid Id { get; set; }
}