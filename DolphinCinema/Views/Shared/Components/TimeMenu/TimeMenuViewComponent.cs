using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Views.Shared.Components.TimeMenu
{
	public class TimeMenuViewComponent : ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
