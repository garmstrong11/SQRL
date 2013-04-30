using SQRL.DataAccess.Abstract;
using System.Linq;

namespace SQRL.DataAccess.Concrete
{
	public class EfUrlLinkRepository : IUrlLinkRepository
	{
		private readonly SqrlContext _context = new SqrlContext();

		public string GetUrlById(string id)
		{
			var link = _context.UrlLinks.Find(id);

			return link != null ? link.LongUrl : "http://www.integracolor.com";
		}
	}
}