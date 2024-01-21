using AutoMapper;
using DolphinCinema.Controllers;
using DolphinCinema.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Areas.AdminPanel.Controllers
{
    [Area("Admin")]
    public class AccountController : BaseMvcController
    {
        public AccountController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
