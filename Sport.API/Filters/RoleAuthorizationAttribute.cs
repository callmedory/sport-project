using Microsoft.AspNetCore.Mvc;
using Sport.Models.Entities;

namespace Sport.API.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RoleAuthorizationAttribute : TypeFilterAttribute
    {
        public RoleAuthorizationAttribute(params UserRoles[] acceptedRoles)
            : base(typeof(RoleAuthorizationFilter))
        {
            Arguments = new object[] { acceptedRoles };
        }
    }
}