using HowdyNeighbor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HowdyNeighbor.Authorization
{
    public class SearchListIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, SearchList>
    {
        UserManager<IdentityUser> _userManager;
        
        public SearchListIsOwnerAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, SearchList resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for CRUD permission, return.

            if (requirement.Name != "Create" &&
                requirement.Name != "Read" &&
                requirement.Name != "Update" &&
                requirement.Name != "Delete")
            {
                return Task.CompletedTask;
            }

            if (resource.OwnerID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
