using System;
using System.Collections.Generic;


namespace boilerplate.web.Models
{
    public partial class MPermissions
    {
        public MPermissions()
        {
            RolePermissons = new HashSet<RolePermissons>();
        }

        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int ParentId { get; set; }
        public bool IsMenu { get; set; }

        public ICollection<RolePermissons> RolePermissons { get; set; }
    }
}
