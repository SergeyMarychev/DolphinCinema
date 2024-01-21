namespace DolphinCinema.Models.Home
{
	public class PosterItemViewModel
	{
		public string PathToImage { get; set; }
		public string Title { get; set; }
		public int AgeLable { get; set; }
		public IEnumerable<string> Genres { get; set; }
		public IEnumerable<PosterItemSeanceViewModel> Seances { get; set; }
	}
}
