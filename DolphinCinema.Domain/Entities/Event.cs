namespace DolphinCinema.Domain.Entities
{
	public class Event : Entity
	{
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public string PathToImage { get; set; }
		public DateTime Date { get; set; }

		public Event()
		{
			Date = DateTime.Now;
		}
	}
}
