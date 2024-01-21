using AutoMapper;
using DolphinCinema.Domain;
using DolphinCinema.Models.Cinemas;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Controllers
{
    [Route("cinema")]
    public class CinemaController : BaseMvcController
    {
        public CinemaController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public IActionResult Index()
        {
            var cinema = Context.Cinemas.FirstOrDefault();
            if (cinema == null)
            {
                return NotFound(); // TODO Обработать ошибку 404
            }

            var model = Mapper.Map<CinemaViewModel>(cinema);
            return View(model);
        }
    }
}
