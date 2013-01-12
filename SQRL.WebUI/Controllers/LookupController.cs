using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SQRL.WebUI.Controllers
{
	public class LookupController : Controller
	{
		//
		// GET: /Lookup/

		public ActionResult Index(string id)
		{
			var siteDict = new Dictionary<string, string>(StringComparer.Ordinal) {
				{"ABCDE", "http://www.amazon.com"},
				{"AbCDE", "http://www.integracolor.com"},
				{"BC9EF", "http://www.google.com"},
				{"SQRLE", "http://localhost:50082/Home/Index"}
			};

			if (siteDict.ContainsKey(id)) {
				return RedirectPermanent(siteDict[id]);
			}

			return HttpNotFound();
		}
	}
}
