namespace DolphinCinema.Domain.Seeds
{
    public class Seed
    {
        private readonly DolphinCinemaDbContext _context;

        public Seed(DolphinCinemaDbContext context)
        {
            _context = context;
        }

        public void Init()
        {
            new PermissionsSeed(_context).Init();
            new RolesSeed(_context).Init();
        }
    }
}
