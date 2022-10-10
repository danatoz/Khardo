namespace ParseManufacturer.Core
{
	public interface IParseSettings
	{

		public string BaseUrl { get; set; }

		public string Prefix { get; set; }

		public int StartPoint { get; set; }

		public int EndPoint { get; set; }
	}
}
