namespace DolphinCinema.Domain.Permissions
{
    public class PermissionManager
    {
        private readonly DolphinCinemaDbContext _context;

        public PermissionManager(DolphinCinemaDbContext context)
        {
            _context = context;
        }

        public bool Check(string permissionName, string roleName)
        {
            var role = _context.Roles.First(r => r.Name == roleName);
            var permission = _context.Permissions.First(p => p.Name == permissionName);

            return _context.RolePermissions.Any(rp => rp.RoleId == role.Id && rp.PermissionId == permission.Id);
        }
    }
}
