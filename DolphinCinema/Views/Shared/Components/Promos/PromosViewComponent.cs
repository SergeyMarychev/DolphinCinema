using DolphinCinema.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Views.Shared.Components.Promos
{
    public class PromosViewComponent : ViewComponent
    {
        private readonly DolphinCinemaDbContext _context;

        public PromosViewComponent(DolphinCinemaDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var now = DateTime.Now;
            //var promos = _context.Promos.Where(p => p.IsActive && (p.DateStart.HasValue ? now >= p.DateStart : true) && (p.DateEnd.HasValue ? now <= p.DateEnd : true));
            var promos = _context.Promos
                .Where(p => p.IsActive)
				.Where(p => p.IsActive && (p.DateStart.HasValue ? now >= p.DateStart : true) && (p.DateEnd.HasValue ? now <= p.DateEnd : true))
                //.WhereIf(p => p.DateStart.HasValue, p => now >= p.DateStart)
                //.WhereIf(p => p.DateEnd.HasValue, p => now <= p.DateEnd)
                .ToList();

            return View(new PromosViewModel(promos));
        }
    }
}
