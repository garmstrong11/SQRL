using System.Linq;
using SQRL.Domain;

namespace SQRL.DataAccess.Abstract
{
	public interface ICategoryRepository
	{
		IQueryable<Category> Categories { get; }
	}
}