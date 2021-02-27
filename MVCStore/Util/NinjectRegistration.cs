using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MVCStore.Domain.Infrastructure;
using MVCStore.Domain.Interfaces;
using Ninject;
using Ninject.Modules;

namespace MVCStore.Util
{
    public class NinjectRegistration : NinjectModule
    {
        private string connectinString;

        public NinjectRegistration(string connection)
        {
            connectinString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectinString);
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
        }
    }
}