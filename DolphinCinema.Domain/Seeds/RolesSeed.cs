using DolphinCinema.Domain.Entities;
using DolphinCinema.Domain.Permissions;

namespace DolphinCinema.Domain.Seeds
{
    public class RolesSeed
    {
        private readonly DolphinCinemaDbContext _context;

        public RolesSeed(DolphinCinemaDbContext context)
        {
            _context = context;
        }

        public void Init()
        {
            var adminPermissions = new[]
            {
                PermissionNames.Seances.view,
                PermissionNames.Seances.delete,
                PermissionNames.Seances.add,
                PermissionNames.Seances.update,
                PermissionNames.Seances.buyTicket,

                PermissionNames.Halls.view,
                PermissionNames.Halls.delete,
                PermissionNames.Halls.add,
                PermissionNames.Halls.update,

                PermissionNames.Movies.view,
                PermissionNames.Movies.delete,
                PermissionNames.Movies.add,
                PermissionNames.Movies.update,

                PermissionNames.Users.view,
                PermissionNames.Users.delete,
                PermissionNames.Users.add,
                PermissionNames.Users.update,
            };

            CreateIfNotExist("Администратор", adminPermissions);

            var cashierPermissions = new[]
            {
                PermissionNames.Seances.view,
                PermissionNames.Seances.buyTicket,
                PermissionNames.Halls.view,
                PermissionNames.Movies.view,
            };

            CreateIfNotExist("Кассир", cashierPermissions);
        }

        private void CreateIfNotExist(string roleName, IEnumerable<string> permissionNames)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                role = new Role(roleName);

                _context.Roles.Add(role);
                _context.SaveChanges();
            }

            foreach (var permissionName in permissionNames)
            {
                var permission = _context.Permissions.First(p => p.Name == permissionName);
                var rolePermission = _context.RolePermissions.FirstOrDefault(rp => rp.RoleId == role.Id && rp.PermissionId == permission.Id);
                if (rolePermission == null)
                {
                    _context.RolePermissions.Add(new RolePermission(role.Id, permission.Id));
                    _context.SaveChanges();
                }
            }
        }
    }
}
