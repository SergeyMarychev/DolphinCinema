using System.ComponentModel.DataAnnotations.Schema;

namespace DolphinCinema.Domain.Entities
{
    public class Permission : Entity
    {
        public int PermissionGroupId { get; set; }

        [ForeignKey("PermissionGroupId")]
        public PermissionGroup PermissionGroup { get; set; }

        public string Name { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public Permission(int permissionGroupId, string name)
        {
            PermissionGroupId = permissionGroupId;
            Name = name;
        }
    }
}
