using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportsStore.Pages.Users
{
    public class ListModel : PageModel
    {
        public UserManager<IdentityUser> UserManager;

        public ListModel(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public IEnumerable<IdentityUser> Users { get; set; }
            = Enumerable.Empty<IdentityUser>();

        public void OnGet()
        {
            Users = UserManager.Users;
        }
    }
}
