using System.Collections.Generic;
using Sitecore.Security.Accounts;

namespace Sitecore.Foundation.Fields.Fields
{
    public interface IRolesField
    {
        IEnumerable<Role> GetSelectedRoles();
        IEnumerable<Role> GetUnselectedRoles();
    }
}

