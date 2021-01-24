using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Covid.DSS.Common.Models
{
    public class UserIdentityContext
    {
        public ClaimsPrincipal User { get; set; }
        public UserManager<IdentityUser> UserManager { get; set; }

        public UserIdentityContext(ClaimsPrincipal claimsPrincipal, UserManager<IdentityUser> userManager)
        {
            User = claimsPrincipal;
            UserManager = userManager;
        }

        public string GetUserId()
        {
            return UserManager.GetUserId(User);
        }
    }
}
