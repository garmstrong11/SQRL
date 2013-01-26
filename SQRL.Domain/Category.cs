using System.Collections.Generic;

namespace SQRL.Domain
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public string LongUrlFormatString { get; set; }

		public virtual List<UrlLink> UrlLinks { get; set; }
	}
}