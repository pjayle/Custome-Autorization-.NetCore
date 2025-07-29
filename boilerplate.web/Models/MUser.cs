using System;
using System.Collections.Generic;

namespace boilerplate.web.Models
{
    public partial class MUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RolesId { get; set; }
        public MRoles? Roles { get; set; }
    }
}
