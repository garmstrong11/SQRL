using System;

namespace SQRL.Domain
{
	public class UrlLink
	{
		public string UrlLinkId { get; set; }
		public string Name { get; set; }
		public string LongUrl { get; set; }
		public Category Category { get; set; }
		public int CategoryId { get; set; }
		public DateTime Created { get; set; }

		public UrlLink()
		{
			UrlLinkId = RandomGen.RandomString(5);
			Created = DateTime.Now;
		}
	}
}