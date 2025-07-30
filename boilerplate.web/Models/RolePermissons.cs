using System;
using System.Collections.Generic;
namespace boilerplate.web.Models
{
    public partial class RolePermissons
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        //public MPermissions permissions { get; set; }
        //public MRoles mRoles { get; set; }
    }
}
