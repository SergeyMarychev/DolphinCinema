using AutoMapper;
using DolphinCinema.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Controllers
{
    [Route("release")]
    public class ReleaseController : BaseMvcController
    {
        public ReleaseController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}