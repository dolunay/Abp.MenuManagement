using FluentValidation;
using Microsoft.Extensions.Localization;
using Snow.MenuManagement.Localization;
using SuperAbp.MenuManagement.Localization;

namespace SuperAbp.MenuManagement.Menus
{
    public class MenuUpdateDtoValidator : AbstractValidator<MenuUpdateDto>
    {
        public MenuUpdateDtoValidator(IStringLocalizer<MenuManagementResource> localizer)
        {
            Include(new MenuCreateUpdateDtoValidator(localizer));
        }
    }
}