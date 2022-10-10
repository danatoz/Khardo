
namespace ParseManufacturer.Core.Target
{
	public class ManufacturersSettings : IParseSettings
	{
		public string BaseUrl { get; set; } = "https://пятаяпередача.рф/manufacturers";
		public string Prefix { get; set; }
		public int StartPoint { get; set; }
		public int EndPoint { get; set; }
	}
}
