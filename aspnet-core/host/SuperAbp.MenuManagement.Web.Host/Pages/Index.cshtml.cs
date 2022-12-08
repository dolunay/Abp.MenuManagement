using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace SuperAbp.MenuManagement.Pages;

public class IndexModel : MenuManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
