using FluentValidation;
using Microsoft.Extensions.Localization;
using Snow.MenuManagement.Localization;

namespace SuperAbp.MenuManagement.Menus
{
    public class MenuCreateUpdateDtoValidator : AbstractValidator<MenuCreateOrUpdateDtoBase>
    {
        public MenuCreateUpdateDtoValidator(IStringLocalizer<MenuManagementResource> local)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(local["The {0} field is required.", "{PropertyName}"])
                .NotEmpty()
                .WithMessage(local["The {0} field is required.", "{PropertyName}"]);
            RuleFor(m => m.Sort)
                .GreaterThanOrEqualTo(0)
                .WithMessage(local["The {0} field must greater than or equal to {1}.", "{PropertyName}", "{PropertyValue}"]);
        }
    }
}