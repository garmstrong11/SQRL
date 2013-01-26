using System.Linq;
using SQRL.DataAccess.Abstract;
using SQRL.Domain;

namespace SQRL.DataAccess.Concrete
{
	public class EfCategoryRepository : ICategoryRepository
	{
		private readonly SqrlContext _context = new SqrlContext();

		#region ICategoryRepository Members

		public IQueryable<Category> Categories
		{
			get { return _context.Categories; }
		}

		#endregion
	}
}