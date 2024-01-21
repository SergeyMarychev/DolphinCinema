namespace DolphinCinema.Models.Seances
{
	public class SeatOnSeanceViewModel
	{
		public int Id { get; set; }
		public int Row { get; set; }
		public int Number { get; set; }
		public int OffsetTop { get; set; }
		public int OffsetLeft { get; set; }
		public bool IsSold { get; set; }
		public int Price { get; set; } 
	}
}
