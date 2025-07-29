using System;
using System.Collections.Generic;

namespace boilerplate.web.Models
{
    public partial class MRoles
    {
        public MRoles()
        {
            Users = new HashSet<MUser>();
            RolePermissons = new HashSet<RolePermissons>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<MUser> Users { get; set; }
        public ICollection<RolePermissons> RolePermissons { get; set; }
    }
}
