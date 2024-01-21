using DolphinCinema.Domain.Entities;
using DolphinCinema.Domain.Permissions;

namespace DolphinCinema.Domain.Seeds
{
    public class PermissionsSeed
    {
        private readonly DolphinCinemaDbContext _context;

        public PermissionsSeed(DolphinCinemaDbContext context)
        {
            _context = context;
        }

        public void Init()
        {
            CreateIfNotExist(PermissionNames.Seances.groupName);
            CreateIfNotExist(PermissionNames.Movies.groupName);
            CreateIfNotExist(PermissionNames.Halls.groupName);
            CreateIfNotExist(PermissionNames.Users.groupName);

            var groupsPermissions = new[]
            {
                new
                {
                    GroupName = PermissionNames.Seances.groupName,
                    Permissions = new []
                    {
                        PermissionNames.Seances.add,
                        PermissionNames.Seances.buyTicket,
                        PermissionNames.Seances.delete,
                        PermissionNames.Seances.update,
                        PermissionNames.Seances.view
                    }
                },

                new
                {
                    GroupName = PermissionNames.Movies.groupName,
                    Permissions = new []
                    {
                        PermissionNames.Movies.add,
                        PermissionNames.Movies.delete,
                        PermissionNames.Movies.update,
                        PermissionNames.Movies.view
                    }
                },

                new
                {
                    GroupName = PermissionNames.Halls.groupName,
                    Permissions = new []
                    {
                        PermissionNames.Halls.add,
                        PermissionNames.Halls.delete,
                        PermissionNames.Halls.update,
                        PermissionNames.Halls.view
                    }
                },

                new
                {
                    GroupName = PermissionNames.Users.groupName,
                    Permissions = new []
                    {
                        PermissionNames.Users.add,
                        PermissionNames.Users.delete,
                        PermissionNames.Users.update,
                        PermissionNames.Users.view
                    }
                }
            };

            foreach (var group in groupsPermissions)
            {
                foreach (var permission in group.Permissions)
                {
                    CreateIfNotExist(group.GroupName, permission);
                }
            }
        }

        private void CreateIfNotExist(string groupName)
        {
            var group = _context.PermissionGroups.FirstOrDefault(p => p.Name == groupName);
            if (group == null)
            {
                _context.PermissionGroups.Add(new PermissionGroup(groupName));
                _context.SaveChanges();
            }
        }

        private void CreateIfNotExist(string groupName, string permissionName)
        {
            //var group = _context.PermissionGroups.FirstOrDefault(p => p.Name == groupName);
            //if (group != null)
            //{
            //    var permission = _context.Permissions.FirstOrDefault(p => p.Name == permissionName);
            //    if (permission == null)
            //    {
            //        _context.Permissions.Add(new Permission(group.Id, permissionName));
            //        _context.SaveChanges();
            //    }
            //}
        }
    }
}
