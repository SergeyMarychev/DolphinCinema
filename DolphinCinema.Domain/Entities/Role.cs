namespace DolphinCinema.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public Role(string name)
        {
            Name = name;
        }
    }
}
