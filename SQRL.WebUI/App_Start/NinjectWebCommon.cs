using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Moq;
using Ninject;
using Ninject.Web.Common;
using SQRL.DataAccess.Abstract;
using SQRL.DataAccess.Concrete;
using SQRL.Domain;
using SQRL.WebUI.App_Start;
using SQRL.WebUI.Infrastructure;
using WebActivator;

[assembly: WebActivator.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectWebCommon), "Stop")]

namespace SQRL.WebUI.App_Start
{
	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

			RegisterServices(kernel);
			GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
			return kernel;
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			//var mock = new Mock<ICategoryRepository>();
			//mock.Setup(m => m.Categories).Returns(new List<Category> {
			//  new Category {Name = "TestCat1", Id = 1, LongUrlFormatString = "http://www.Amazon.com"},
			//  new Category {Name = "TestCat2", Id = 2, LongUrlFormatString = "http://www.google.com"}
			//}.AsQueryable());

			kernel.Bind<ICategoryRepository>().To<EfCategoryRepository>();
		}
	}
}