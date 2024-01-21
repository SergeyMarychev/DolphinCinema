using DolphinCinema.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Views.Shared.Components.Slider
{
	public class SliderViewComponent : ViewComponent
	{
		private readonly DolphinCinemaDbContext _context;

		public SliderViewComponent(DolphinCinemaDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var images = _context.Sliders.Select(s => s.PathToImage).ToList();
			return View(images);
		}
	}
}
