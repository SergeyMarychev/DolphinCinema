using AutoMapper;
using DolphinCinema.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Controllers
{
	public abstract class BaseMvcController : Controller
	{
		protected DolphinCinemaDbContext Context { get; set; }
		protected IMapper Mapper { get; set; }

        protected BaseMvcController(DolphinCinemaDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}
