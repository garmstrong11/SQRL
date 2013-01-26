using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace SQRL.WebUI.Infrastructure
{
	public class NinjectScope : IDependencyScope
	{
		protected IResolutionRoot ResolutionRoot;

		public NinjectScope(IResolutionRoot kernel)
		{
			ResolutionRoot = kernel;
		}

		#region IDependencyScope Members

		public object GetService(Type serviceType)
		{
			return ResolveRequest(serviceType).SingleOrDefault();
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return ResolveRequest(serviceType).ToList();
		}

		public void Dispose()
		{
			var disposable = (IDisposable) ResolutionRoot;
			if (disposable != null) disposable.Dispose();
			ResolutionRoot = null;
		}

		#endregion

		private IEnumerable<object> ResolveRequest(Type serviceType)
		{
			IRequest req = ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
			return ResolutionRoot.Resolve(req);
		}
	}
}