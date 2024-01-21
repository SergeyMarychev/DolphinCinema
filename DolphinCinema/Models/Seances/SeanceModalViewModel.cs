using DolphinCinema.Models.Home;

namespace DolphinCinema.Models.Seances
{
	public class SeanceModalViewModel
	{
		public string Title { get; set; }
		public IEnumerable<PosterItemSeanceViewModel> Seances { get; set; }
		public string Date { get; set; }
		public IEnumerable<SeatOnSeanceViewModel> Seats { get; set; }
	}
}
