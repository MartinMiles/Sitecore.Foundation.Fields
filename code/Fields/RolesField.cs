using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Security.Accounts;
using Sitecore.Text;

namespace Sitecore.Foundation.Fields.Fields
{
    public class RolesField : IRolesField
    {
        private static readonly string DomainParameterName = Settings.GetSetting("RolesField.DomainParameterName");

        private ListString _SelectedRoles;
        private ListString SelectedRoles
        {
            get
            {
                if (_SelectedRoles == null)
                {
                    _SelectedRoles = new ListString(Value);
                }

                return _SelectedRoles;
            }
        }

        private IEnumerable<Role> _RolesInDomain;
        private IEnumerable<Role> RolesInDomain
        {
            get
            {
                if (_RolesInDomain == null)
                {
                    _RolesInDomain = GetRolesInDomain();
                }

                return _RolesInDomain;
            }
        }

        private IEnumerable<Role> _Roles;
        private IEnumerable<Role> Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = GetRoles();
                }

                return _Roles;
            }
        }

        private string Domain => GetFieldSettings()[DomainParameterName];

        private string Source { get; set; }
        private string Value { get; set; }

        private RolesField(string source, string value)
        {
            SetSource(source);
            SetValue(value);
        }

        private void SetSource(string source)
        {
            Source = source;
        }

        private void SetValue(string value)
        {
            Value = value;
        }

        private IEnumerable<Role> GetRolesInDomain()
        {
            if (!string.IsNullOrEmpty(Domain))
            {
                return Roles.Where(role => role.Domain.Name == Domain);
            }

            return Roles;
        }

        private static IEnumerable<Role> GetRoles()
        {
            IEnumerable <Role> roles = RolesInRolesManager.GetAllRoles(); 

            if (roles != null)
            {
                return roles;
            }

            return new List<Role>();
        }

        private UrlString GetFieldSettings()
        {
            try
            {
                if (!string.IsNullOrEmpty(Source))
                {
                    return new UrlString(Source);
                }
            }
            catch (Exception ex)
            {
                Log.Error(this.ToString(), ex, this);
            }

            return new UrlString();
        }

        public IEnumerable<Role> GetSelectedRoles()
        {
            IList<Role> selectedRoles = new List<Role>();

            foreach (string key in SelectedRoles)
            {
                Role selectedRole = RolesInDomain.Where(role => role.Name == key).FirstOrDefault();
                if (selectedRole != null)
                {
                    selectedRoles.Add(selectedRole);
                }
            }

            return selectedRoles;
        }

        public IEnumerable<Role> GetUnselectedRoles()
        {
            IList<Role> unselectedRoles = new List<Role>();

            foreach (Role role in RolesInDomain)
            {
                if (!IsRoleSelected(role))
                {
                    unselectedRoles.Add(role);
                }
            }

            return unselectedRoles;
        }

        private bool IsRoleSelected(Role role)
        {
            return SelectedRoles.IndexOf(role.Name) > -1;
        }

        public static IRolesField CreateNewRolesField(string source, string value)
        {
            return new RolesField(source, value);
        }
    }
}