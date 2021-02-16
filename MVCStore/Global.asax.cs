using Catel.Data;
using MVCStore.Domain.Core;
using MVCStore.Infrastructure.Binders;
using MVCStore.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //Какая-то херня с Нинжектом, вылетает ошибка валидации некоторых полей, нашел в инете решение.
            ModelValidatorProviders.Providers.Clear();



            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Биндим корзину
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            NinjectModule registrations = new NinjectRegistration("DefaultConnection");
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
