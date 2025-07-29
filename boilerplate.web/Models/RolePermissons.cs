using System;
using System.Collections.Generic;
namespace boilerplate.web.Models
{
    public partial class RolePermissons
    {
        public int Id { get; set; }
        public int RolesId { get; set; }
        public int MenusId { get; set; }

        public MPermissions permissions { get; set; }
        public MRoles mRoles { get; set; }
    }
}
