namespace boilerplate.web.Models.Dto
{
    public class LoggedInUser
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class LoggeInUserRolePermission
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public string Url { get; set; }
        public string ParentId { get; set; }
        public bool IsMenu { get; set; }
        public string Description { get; set; }
        public int SequenceNo { get; set; }

    }
}
