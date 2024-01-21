using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Views.Shared.Components.Input
{
    public class InputViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string id = null, string className = null, string type = "text", string placeholder = "")
        {
            return View(new InputViewModel(id, className, type, placeholder));
        }
    }
}
