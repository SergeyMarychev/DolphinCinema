namespace DolphinCinema.Domain.Entities
{
    public class PermissionGroup : Entity
    {
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }

        public PermissionGroup(string name)
        {
            Name = name;
        }
    }
}
