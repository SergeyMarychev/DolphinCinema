using AutoMapper;
using DolphinCinema.Areas.Admin.Models.Hall;
using DolphinCinema.Controllers;
using DolphinCinema.Domain;
using DolphinCinema.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DolphinCinema.Areas.AdminPanel.Controllers
{
    [Area("Admin")]
    public class HallController : BaseMvcController
    {
        public HallController(DolphinCinemaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHallDto input)
        {
			string trimmedName = input.Name.Trim(); 

			if (string.IsNullOrEmpty(trimmedName))
			{
				return BadRequest("Введите название зала!");
			}

			if (Context.Halls.Any(h => h.Name == trimmedName))
			{
				return BadRequest("Зал с таким названием уже существует!");
			}

			var hall = new Hall
			{
				Name = trimmedName,
				Seats = input.Seats?.ToList() ?? new List<Seat>()
			};

			await Context.Halls.AddAsync(hall);
			await Context.SaveChangesAsync();

			return Ok();
		}
    }
}
