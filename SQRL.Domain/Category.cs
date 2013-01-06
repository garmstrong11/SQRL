using System.Collections.Generic;

namespace SQRL.Domain
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LongUrlFormatString { get; set; }
		//public Category Parent { get; set; }

		public List<UrlLink> UrlLinks { get; set; }
	}
}