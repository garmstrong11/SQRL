using System;

namespace SQRL.Domain
{
	public class UrlLink
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string LongUrl { get; set; }
		public Category Parent { get; set; }
		public DateTime Created { get; set; }

		public UrlLink()
		{
			Id = RandomGen.RandomString(5);
			Created = DateTime.Now;
		}
	}
}